using BloggingPlatform.Domain.Common;

namespace BloggingPlatform.Domain.Abstractions;
public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity);
}
