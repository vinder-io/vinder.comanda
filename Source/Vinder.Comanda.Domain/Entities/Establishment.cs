namespace Vinder.Comanda.Domain.Entities;

public sealed class Establishment : Entity
{
    public string Name { get; private set; } = default!;
    public string Slug { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public Owner Owner { get; private set; } = default!;
    public Branding Branding { get; private set; } = default!;

    public IEnumerable<Product> Products { get; private set; } = [];
    public IEnumerable<Category> Categories { get; private set; } = [];

    public void SetEstablishmentDescription(string description) =>
        Description = description.Trim().Normalize(NormalizationForm.FormC);

    public void SetEstablishmentName(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);

    public void SetEstablishmentSlug(string slug) =>
        Slug = slug.Trim().Normalize(NormalizationForm.FormC).ToLowerInvariant();

    public void SetEstablishmentProducts(IEnumerable<Product> products) =>
        Products = products;

    public void SetEstablishmentCategories(IEnumerable<Category> categories) =>
        Categories = categories;

    public void SetEstablishmentOwner(Owner owner) =>
        Owner = owner;

    public void SetEstablishmentBranding(Branding branding) =>
        Branding = branding;
}
