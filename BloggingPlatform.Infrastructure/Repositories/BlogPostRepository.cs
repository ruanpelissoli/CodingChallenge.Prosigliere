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

    public async Task<IEnumerable<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.ToListAsync(cancellationToken);

    public async Task<BlogPost?> GetByIdAsync(BlogPostId id, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Include(i => i.Comments)
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
}
