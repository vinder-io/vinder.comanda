namespace Vinder.Comanda.Domain.Contracts;

public interface IOwnerRepository : IBaseRepository<Owner>
{
    public Task<IReadOnlyCollection<Owner>> GetOwnersAsync(
        OwnerFilters filters,
        CancellationToken cancellation = default
    );

    public Task<long> CountAsync(
        OwnerFilters filters,
        CancellationToken cancellation = default
    );
}