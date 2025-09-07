namespace Vinder.Comanda.Domain.ValueObjects;

public sealed record Image
{
    public string Url { get; init; }

    public Image(string url)
    {
        Url = url.Trim().Normalize(NormalizationForm.FormC);
    }
}