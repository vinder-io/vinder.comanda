namespace Vinder.Comanda.Domain.Entities;

public sealed class Item : Entity
{
    public decimal UnitPrice { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;

    public ItemMetadata Metadata { get; private set; } = default!;

    public void SetUnitPrice(decimal price) =>
        UnitPrice = price;

    public void SetQuantity(int quantity) =>
        Quantity = quantity;

    public void SetMetadata(ItemMetadata metadata) =>
        Metadata = metadata;
}
