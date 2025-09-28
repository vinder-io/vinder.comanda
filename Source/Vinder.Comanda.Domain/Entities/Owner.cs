namespace Vinder.Comanda.Domain.Entities;

public sealed class Owner : Entity
{
    public string Name { get; private set; } = default!;
    public Subscription Subscription { get; private set; } = default!;
    public Identity Identity { get; private set; } = default!;

    public void SetIdentity(Identity identity) =>
        Identity = identity;

    public void SetSubscription(Subscription subscription) =>
        Subscription = subscription;

    public void SetName(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);
}