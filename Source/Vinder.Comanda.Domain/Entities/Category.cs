namespace Vinder.Comanda.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; } = default!;

    public void SetName(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);
}