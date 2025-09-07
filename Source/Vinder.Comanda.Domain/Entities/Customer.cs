namespace Vinder.Comanda.Domain.Entities;

public sealed class Customer : Entity
{
    public Identity Identity { get; private set; } = default!;

    public void SetCustomerIdentity(Identity identity) =>
        Identity = identity;
}