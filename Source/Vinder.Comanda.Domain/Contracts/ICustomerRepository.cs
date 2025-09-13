namespace Vinder.Comanda.Domain.Contracts;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    public Task<IReadOnlyCollection<Customer>> GetCustomersAsync(
        CustomerFilters filters,
        CancellationToken cancellation = default
    );

    public Task<long> CountAsync(
        CustomerFilters filters,
        CancellationToken cancellation = default
    );
}