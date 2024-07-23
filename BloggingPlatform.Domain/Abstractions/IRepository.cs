using BloggingPlatform.Domain.Common;

namespace BloggingPlatform.Domain.Abstractions;
public interface IRepository<TEntity, TEntityId> where TEntity : IEntity
{
    Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity);
}
