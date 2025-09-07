namespace Vinder.Comanda.Domain.ValueObjects;

public sealed record ProductMetadata
{
    public int EstablishmentId { get; init; }
    public int CategoryId { get; init; }
}