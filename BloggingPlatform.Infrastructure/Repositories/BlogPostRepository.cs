using BloggingPlatform.Domain.BlogPosts;
using BloggingPlatform.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Infrastructure.Repositories;
internal class BlogPostRepository : IBlogPostRepository
{
    private readonly DbSet<BlogPost> _dbContext;

    public BlogPostRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext.Set<BlogPost>();
    }

    public async Task AddAsync(BlogPost entity)
    {
        await _dbContext.AddAsync(entity);
    }

    public Task<List<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
