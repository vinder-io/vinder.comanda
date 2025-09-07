namespace Vinder.Comanda.Domain.ValueObjects;

public sealed record OrderMetadata
{
    public string EstablishmentId { get; init; } = default!;
    public string PaymentId { get; init; } = default!;
    public string CustomerId { get; init; } = default!;
}
