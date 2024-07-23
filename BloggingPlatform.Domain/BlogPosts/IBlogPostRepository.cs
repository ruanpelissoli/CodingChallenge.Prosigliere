using BloggingPlatform.Domain.Abstractions;

namespace BloggingPlatform.Domain.BlogPosts;
public interface IBlogPostRepository : IRepository<BlogPost, BlogPostId>
{
    Task<IEnumerable<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default);
}
