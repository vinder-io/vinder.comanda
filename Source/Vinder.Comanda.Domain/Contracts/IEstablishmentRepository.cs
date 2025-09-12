namespace Vinder.Comanda.Domain.Contracts;

public interface IEstablishmentRepository : IBaseRepository<Establishment>
{
    public Task<IReadOnlyCollection<Establishment>> GetEstablishmentsAsync(
        EstablishmentFilters filters,
        CancellationToken cancellation = default
    );
}