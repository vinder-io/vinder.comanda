namespace Vinder.Comanda.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }

    public ProductMetadata Metadata { get; private set; } = default!;
    public Image Image { get; private set; } = default!;

    public void SetProductDescription(string description) =>
        Description = description.Trim().Normalize(NormalizationForm.FormC);

    public void SetProductName(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);

    public void SetProductPrice(decimal price) =>
        Price = price;

    public void SetProductImage(Image image) =>
        Image = image;

    public void SetProductMetadata(ProductMetadata metadata) =>
        Metadata = metadata;
}