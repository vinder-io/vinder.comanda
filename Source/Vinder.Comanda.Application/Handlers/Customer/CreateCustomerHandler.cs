namespace Vinder.Comanda.Application.Handlers.Customer;

public sealed class CreateCustomerHandler(ICustomerRepository repository) :
    IRequestHandler<CreateCustomerRequest, Result<CustomerDetails>>
{
    public async Task<Result<CustomerDetails>> Handle(
        CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var filters = CustomerFilters.WithSpecifications()
            .WithEmail(request.Email)
            .Build();

        var matchingCustomers = await repository.GetCustomersAsync(filters, cancellationToken);
        var existingCustomer = matchingCustomers.FirstOrDefault();

        if (existingCustomer is not null)
        {
            // when customer already exists raise error: #COMANDA-ERROR-76A714 (comment only for tracking purposes)
            return Result<CustomerDetails>.Failure(CustomerErrors.CustomerAlreadyExists);
        }

        var customer = CustomerMapper.AsCustomer(request);
        var result = await repository.InsertAsync(customer, cancellationToken);

        return Result<CustomerDetails>.Success(CustomerMapper.AsResponse(result));
    }
}