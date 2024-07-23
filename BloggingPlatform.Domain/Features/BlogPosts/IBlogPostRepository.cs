using BloggingPlatform.Domain.Abstractions;

namespace BloggingPlatform.Domain.Features.BlogPosts;
public interface IBlogPostRepository : IRepository<BlogPost, BlogPostId>
{
    Task<IEnumerable<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default);
}
