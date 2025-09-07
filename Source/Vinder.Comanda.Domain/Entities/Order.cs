namespace Vinder.Comanda.Domain.Entities;

public sealed class Order : Entity
{
    public OrderMetadata Metadata { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = default!;
    public ICollection<Item> Items { get; private set; } = [];

    public void SetOrderMetadata(OrderMetadata metadata) =>
        Metadata = metadata;

    public void SetOrderStatus(OrderStatus status) =>
        Status = status;
}
