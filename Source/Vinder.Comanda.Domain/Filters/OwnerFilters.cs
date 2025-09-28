namespace Vinder.Comanda.Domain.Filters;

public sealed class OwnerFilters : PaginationFilters
{
    public string? Id { get; private set; } = default!;
    public string? Name { get; private set; } = default!;
    public string? UserId { get; private set; } = default!;
    public string? Email { get; private set; } = default!;
    public bool? IsDeleted { get; private set; } = default!;
    public SubscriptionStatus? SubscriptionStatus { get; private set; }

    public static OwnerFiltersBuilder WithSpecifications() => new();

    public void SetIdFilter(string? id) =>
        Id = string.IsNullOrWhiteSpace(id) ? null : id.Trim()
            .Normalize(NormalizationForm.FormC);

    public void SetNameFilter(string? name) =>
        Name = string.IsNullOrWhiteSpace(name) ? null : name.Trim()
            .Normalize(NormalizationForm.FormC);

    public void SetUserIdFilter(string? userId) =>
        UserId = string.IsNullOrWhiteSpace(userId) ? null : userId.Trim()
            .Normalize(NormalizationForm.FormC);

    public void SetEmailFilter(string? email) =>
        Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim()
            .Normalize(NormalizationForm.FormC);

    public void SetIsDeletedFilter(bool? isDeleted) =>
        IsDeleted = isDeleted;

    public void SetSubscriptionStatusFilter(SubscriptionStatus? status) =>
        SubscriptionStatus = status;
}