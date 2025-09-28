namespace Vinder.Comanda.Application.Payloads.Customer;

public sealed record CustomersFetchParameters : IRequest<Result<Pagination<CustomerDetails>>>
{
    public string? Id { get; init; } = default!;
    public string? Name { get; init; } = default!;
    public string? Email { get; init; } = default!;
    public string? UserId { get; init; } = default!;

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 60;
}