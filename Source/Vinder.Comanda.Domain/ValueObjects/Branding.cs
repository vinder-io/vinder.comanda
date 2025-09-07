namespace Vinder.Comanda.Domain.ValueObjects;

public sealed record Branding
{
    public string Image { get; init; } = default!;
    public string PrimaryColor { get; init; } = default!;
    public string SecondaryColor { get; init; } = default!;
}