namespace Vinder.Comanda.Domain.Filters;

public sealed class CustomerFilters : PaginationFilters
{
    public string? Id { get; private set; } = default!;
    public string? Name { get; private set; } = default!;
    public string? UserId { get; private set; } = default!;
    public string? Email { get; private set; } = default!;
    public bool? IsDeleted { get; private set; } = default!;

    public static CustomerFiltersBuilder ToBuilder() => new();

    public void SetIdentifier(string id) =>
        Id = id.Trim().Normalize(NormalizationForm.FormC);

    public void SetName(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);

    public void SetUserId(string userId) =>
        UserId = userId.Trim().Normalize(NormalizationForm.FormC);

    public void SetEmail(string email) =>
        Email = email.Trim().Normalize(NormalizationForm.FormC);

    public void SetIsDeleted(bool isDeleted) =>
        IsDeleted = isDeleted;
}