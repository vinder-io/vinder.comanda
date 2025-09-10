namespace Vinder.Comanda.Domain.Entities;

public sealed class Owner : Entity
{
    public string Name { get; private set; } = default!;
    public Subscription Subscription { get; private set; } = default!;
    public Identity Identity { get; private set; } = default!;

    public void SetOwnerIdentity(Identity identity) =>
        Identity = identity;

    public void SetOwnerSubscription(Subscription subscription) =>
        Subscription = subscription;

    public void SetOwnerName(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);
}