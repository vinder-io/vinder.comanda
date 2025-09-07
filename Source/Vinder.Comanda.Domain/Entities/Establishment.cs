namespace Vinder.Comanda.Domain.Entities;

public sealed class Establishment : Entity
{
    public string Name { get; private set; } = default!;
    public string Slug { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public Owner Owner { get; private set; } = default!;
    public Branding Branding { get; private set; } = default!;

    public ICollection<Product> Products { get; private set; } = [];
    public ICollection<Category> Categories { get; private set; } = [];
    public ICollection<Order> Orders { get; private set; } = [];

    public void SetEstablishmentDescription(string description) =>
        Description = description.Trim().Normalize(NormalizationForm.FormC);

    public void SetEstablishmentName(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);

    public void SetEstablishmentSlug(string slug) =>
        Slug = slug.Trim().Normalize(NormalizationForm.FormC).ToLowerInvariant();

    public void SetEstablishmentOwner(Owner owner) =>
        Owner = owner;

    public void SetEstablishmentBranding(Branding branding) =>
        Branding = branding;
}
