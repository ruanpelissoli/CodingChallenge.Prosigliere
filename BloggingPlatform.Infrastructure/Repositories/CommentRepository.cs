using BloggingPlatform.Domain.Comments;

namespace BloggingPlatform.Infrastructure.Repositories;
internal class CommentRepository : ICommentRepository
{
    public Task AddAsync(Comment entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<Comment>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
