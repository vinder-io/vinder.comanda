namespace Vinder.Comanda.Domain.ValueObjects;

public sealed record Identity
{
    public string UserId { get; init; }
    public string Email { get; init; }

    public Identity(string userId, string email)
    {
        UserId = userId.Trim().Normalize(NormalizationForm.FormC);
        Email = email.Trim().Normalize(NormalizationForm.FormC);
    }
}