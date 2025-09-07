namespace Vinder.Comanda.Domain.Entities;

public sealed class Payment : Entity
{
    public decimal Value { get; private set; } = default!;
    public PaymentMetadata Metadata { get; private set; } = default!;

    public void SetPaymentValue(decimal value) =>
        Value = value;

    public void SetPaymentMetadata(PaymentMetadata metadata) =>
        Metadata = metadata;
}
