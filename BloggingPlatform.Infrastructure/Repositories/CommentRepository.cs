using BloggingPlatform.Domain.Features.BlogPosts;
using BloggingPlatform.Domain.Features.Comments;
using BloggingPlatform.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Infrastructure.Repositories;
internal class CommentRepository : ICommentRepository
{
    private readonly DbSet<Comment> _dbContext;

    public CommentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext.Set<Comment>();
    }

    public async Task AddAsync(Comment entity)
    {
        await _dbContext.AddAsync(entity);
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsAsync(BlogPostId blogPostId) =>
        await _dbContext.Where(w => w.BlogPostId == blogPostId).ToListAsync();

    public async Task<Comment?> GetByIdAsync(CommentId id, CancellationToken cancellationToken = default) =>
        await _dbContext
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
}
