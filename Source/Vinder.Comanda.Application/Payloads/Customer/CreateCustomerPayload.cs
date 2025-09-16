namespace Vinder.Comanda.Application.Payloads.Customer;

public sealed record CreateCustomerRequest : IRequest<Result<CustomerDetails>>
{
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string UserId { get; init; } = default!;
}