namespace Vinder.Comanda.Domain.Entities;

public sealed class Product : Entity
{
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }

    public ProductMetadata Metadata { get; private set; } = default!;
    public Image Image { get; private set; } = default!;

    public void SetDescription(string description) =>
        Description = description.Trim().Normalize(NormalizationForm.FormC);

    public void SetTitle(string title) =>
        Title = title.Trim().Normalize(NormalizationForm.FormC);

    public void SetPrice(decimal price) =>
        Price = price;

    public void SetImage(Image image) =>
        Image = image;

    public void SetMetadata(ProductMetadata metadata) =>
        Metadata = metadata;
}