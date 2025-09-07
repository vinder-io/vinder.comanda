namespace Vinder.Comanda.Domain.Entities;

public sealed class Order : Entity
{
    public OrderMetadata Metadata { get; private set; } = default!;

    public void SetOrderMetadata(OrderMetadata metadata) =>
        Metadata = metadata;
}
