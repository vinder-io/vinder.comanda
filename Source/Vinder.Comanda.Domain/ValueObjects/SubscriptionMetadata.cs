namespace Vinder.Comanda.Domain.ValueObjects;

public sealed record SubscriptionMetadata
{
    public string ExternalId { get; init; } = default!;
    public Identity Subscriber { get; init; } = default!;
}