namespace Vinder.Comanda.Application.Handlers.Customer;

public sealed class FetchCustomersHandler(ICustomerRepository repository) :
    IRequestHandler<CustomersFetchParameters, Result<Pagination<CustomerDetails>>>
{
    public async Task<Result<Pagination<CustomerDetails>>> Handle(
        CustomersFetchParameters request, CancellationToken cancellationToken)
    {
        var filters = CustomerFilters.WithSpecifications()
            .WithCustomerId(request.Id)
            .WithCustomerName(request.Name)
            .WithUserId(request.UserId)
            .WithPageNumber(request.PageNumber)
            .WithPageSize(request.PageSize)
            .Build();

        var customers = await repository.GetCustomersAsync(filters, cancellationToken);
        var total = await repository.CountAsync(filters, cancellationToken);

        var pagination = new Pagination<CustomerDetails>
        {
            Items = [.. customers.Select(customer => CustomerMapper.AsResponse(customer))],
            Total = (int)total,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
        };

        return Result<Pagination<CustomerDetails>>.Success(pagination);
    }
}