namespace Vinder.Comanda.Domain.Filters.Builders;

public sealed class EstablishmentFiltersBuilder
{
    private readonly EstablishmentFilters _filters = new();

    public EstablishmentFiltersBuilder WithId(string? id)
    {
        if (!string.IsNullOrWhiteSpace(id))
        {
            _filters.SetIdFilter(id);
        }

        return this;
    }

    public EstablishmentFiltersBuilder WithOwnerId(string? ownerId)
    {
        if (!string.IsNullOrWhiteSpace(ownerId))
        {
            _filters.SetOwnerIdFilter(ownerId);
        }

        return this;
    }

    public EstablishmentFiltersBuilder WithName(string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            _filters.SetNameFilter(name);
        }

        return this;
    }

    public EstablishmentFiltersBuilder WithIsDeleted(bool isDeleted)
    {
        if (isDeleted)
        {
            _filters.SetIsDeletedFilter(isDeleted);
        }

        return this;
    }

    public EstablishmentFiltersBuilder WithPageNumber(int? pageNumber)
    {
        if (pageNumber.HasValue && pageNumber > 0)
        {
            _filters.PageNumber = pageNumber.Value;
        }

        return this;
    }

    public EstablishmentFiltersBuilder WithPageSize(int? pageSize)
    {
        if (pageSize.HasValue && pageSize > 0)
        {
            _filters.PageSize = pageSize.Value;
        }

        return this;
    }

    public EstablishmentFilters Build() => _filters;
}
