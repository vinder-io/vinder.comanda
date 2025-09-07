namespace Vinder.Comanda.Domain.Entities;

public sealed class Customer : Entity
{
    public string Name { get; private set; } = default!;
    public Identity Identity { get; private set; } = default!;

    public void SetCustomerIdentity(Identity identity) =>
        Identity = identity;

    public void SetCustomerName(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);
}