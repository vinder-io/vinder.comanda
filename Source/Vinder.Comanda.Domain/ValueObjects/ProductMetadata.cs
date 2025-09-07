namespace Vinder.Comanda.Domain.ValueObjects;

public sealed record ProductMetadata
{
    public string EstablishmentId { get; init; } = default!;
    public string CategoryId { get; init; } = default!;
}