using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.BlogPosts;

namespace BloggingPlatform.Infrastructure.Cache;
internal class CachedBlogPostRepository(
    IBlogPostRepository _blogPostRepository,
    ICacheLayer _cache) : IBlogPostRepository
{
    private string CacheKey(Guid id) => string.Format($"blogpost_{id}");

    public async Task AddAsync(BlogPost entity)
    {
        await _blogPostRepository.AddAsync(entity);

        await _cache.Set(CacheKey(entity.Id.Value), entity);
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _blogPostRepository.GetAllAsync(cancellationToken);

    public async Task<BlogPost?> GetByIdAsync(BlogPostId id, CancellationToken cancellationToken = default)
    {
        var cachedObject = await _cache.Get<BlogPost>(CacheKey(id.Value));

        if (cachedObject is null)
        {
            var dbObject = await _blogPostRepository.GetByIdAsync(id, cancellationToken);

            if (dbObject is null)
                return null;

            await _cache.Set(CacheKey(id.Value), dbObject, cancellationToken);

            return dbObject;
        }

        return cachedObject!;
    }
}
