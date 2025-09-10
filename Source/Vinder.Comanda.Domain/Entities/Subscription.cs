namespace Vinder.Comanda.Domain.Entities;

public sealed class Subscription : Entity
{
    public SubscriptionStatus Status { get; private set; } = default!;
    public SubscriptionMetadata Metadata { get; private set; } = default!;

    public void SetSubscriptionStatus(SubscriptionStatus status) =>
        Status = status;

    public void SetSubscriptionMetadata(SubscriptionMetadata metadata) =>
        Metadata = metadata;
}