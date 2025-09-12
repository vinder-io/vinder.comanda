namespace Vinder.Comanda.Domain.Contracts;

public interface IBaseRepository<TEntity>
    where TEntity : Entity
{
    public Task<TEntity> InsertAsync(
        TEntity entity,
        CancellationToken cancellation = default
    );

    public Task<IEnumerable<TEntity>> InsertManyAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellation = default
    );

    public Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellation = default
    );

    public Task<bool> DeleteAsync(
        TEntity entity,
        CancellationToken cancellation = default
    );
}