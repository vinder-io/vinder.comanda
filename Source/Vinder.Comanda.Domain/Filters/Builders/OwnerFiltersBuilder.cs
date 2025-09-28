namespace Vinder.Comanda.Domain.Filters.Builders;

public sealed class OwnerFiltersBuilder
{
    private readonly OwnerFilters _filters = new();

    public OwnerFiltersBuilder WithId(string? id)
    {
        _filters.SetIdFilter(id);
        return this;
    }

    public OwnerFiltersBuilder WithName(string? name)
    {
        _filters.SetNameFilter(name);
        return this;
    }

    public OwnerFiltersBuilder WithUserId(string? userId)
    {
        _filters.SetUserIdFilter(userId);
        return this;
    }

    public OwnerFiltersBuilder WithEmail(string? email)
    {
        _filters.SetEmailFilter(email);
        return this;
    }

    public OwnerFiltersBuilder WithIsDeleted(bool? isDeleted)
    {
        _filters.SetIsDeletedFilter(isDeleted);
        return this;
    }

    public OwnerFiltersBuilder WithSubscriptionStatus(SubscriptionStatus? status)
    {
        _filters.SetSubscriptionStatusFilter(status);
        return this;
    }

    public OwnerFiltersBuilder WithPageNumber(int? pageNumber)
    {
        if (pageNumber.HasValue && pageNumber > 0)
        {
            _filters.PageNumber = pageNumber.Value;
        }

        return this;
    }

    public OwnerFiltersBuilder WithPageSize(int? pageSize)
    {
        if (pageSize.HasValue && pageSize > 0)
        {
            _filters.PageSize = pageSize.Value;
        }

        return this;
    }

    public OwnerFilters Build() => _filters;
}
