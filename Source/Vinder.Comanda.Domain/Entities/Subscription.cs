namespace Vinder.Comanda.Domain.Entities;

public sealed class Subscription : Entity
{
    public SubscriptionStatus Status { get; private set; } = default!;
    public SubscriptionMetadata Metadata { get; private set; } = default!;

    public void SetStatus(SubscriptionStatus status) =>
        Status = status;

    public void SetMetadata(SubscriptionMetadata metadata) =>
        Metadata = metadata;
}