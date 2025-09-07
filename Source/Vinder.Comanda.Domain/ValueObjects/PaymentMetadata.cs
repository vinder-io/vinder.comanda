namespace Vinder.Comanda.Domain.ValueObjects;

public sealed record PaymentMetadata
{
    public string PaymentReferenceId { get; init; } = default!;
    public string EstablishmentId { get; init; } = default!;
    public string OrderId { get; init; } = default!;
    public Identity Payer { get; init; } = default!;
}