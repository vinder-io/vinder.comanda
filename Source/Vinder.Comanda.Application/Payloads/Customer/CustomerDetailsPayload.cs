namespace Vinder.Comanda.Application.Payloads.Customer;

public sealed record CustomerDetails
{
    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
}