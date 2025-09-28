namespace Vinder.Comanda.Domain.Entities;

public sealed class Payment : Entity
{
    public decimal Value { get; private set; } = default!;
    public PaymentMetadata Metadata { get; private set; } = default!;

    public void SeValue(decimal value) =>
        Value = value;

    public void SetMetadata(PaymentMetadata metadata) =>
        Metadata = metadata;
}
