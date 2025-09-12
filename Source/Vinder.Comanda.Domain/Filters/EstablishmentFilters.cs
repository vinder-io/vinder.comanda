namespace Vinder.Comanda.Domain.Filters;

public sealed class EstablishmentFilters : PaginationFilters
{
    public string? Id { get; private set; } = default!;
    public string? OwnerId { get; private set; } = default!;
    public string? Name { get; private set; } = default!;
    public bool? IsDeleted { get; private set; } = default!;

    public static EstablishmentFiltersBuilder ToBuilder() => new();

    public void SetIdFilter(string id) =>
        Id = id.Trim().Normalize(NormalizationForm.FormC);

    public void SetOwnerIdFilter(string ownerId) =>
        OwnerId = ownerId.Trim().Normalize(NormalizationForm.FormC);

    public void SetNameFilter(string name) =>
        Name = name.Trim().Normalize(NormalizationForm.FormC);

    public void SetIsDeletedFilter(bool isDeleted) =>
        IsDeleted = isDeleted;
}
