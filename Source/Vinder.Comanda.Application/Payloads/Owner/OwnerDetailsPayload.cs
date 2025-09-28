namespace Vinder.Comanda.Application.Payloads.Owner;

public sealed record OwnerDetails
{
    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string SubscriptionStatus { get; init; } = default!;

    public bool HasSubscription { get; init; }
    public bool IsSubscriptionActive { get; init; }
}