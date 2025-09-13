namespace Vinder.Comanda.Domain.Filters.Builders;

public sealed class CustomerFiltersBuilder
{
    private readonly CustomerFilters _filters = new();

    public CustomerFiltersBuilder WithCustomerId(string? customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return this;
        }

        _filters.SetIdentifier(customerId);
        return this;
    }

    public CustomerFiltersBuilder WithCustomerName(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return this;
        }

        _filters.SetName(name);
        return this;
    }


    public CustomerFiltersBuilder WithUserId(string? userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return this;
        }

        _filters.SetUserId(userId);
        return this;
    }

    public CustomerFiltersBuilder WithEmail(string? email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return this;
        }

        _filters.SetEmail(email);
        return this;
    }

    public CustomerFiltersBuilder WithIsDeleted(bool isDeleted)
    {
        if (isDeleted)
        {
            _filters.SetIsDeleted(isDeleted);
        }

        return this;
    }

    public CustomerFiltersBuilder WithPageNumber(int? pageNumber)
    {
        if (pageNumber.HasValue && pageNumber > 0)
        {
            _filters.PageNumber = pageNumber.Value;
        }

        return this;
    }

    public CustomerFiltersBuilder WithPageSize(int? pageSize)
    {
        if (pageSize.HasValue && pageSize > 0)
        {
            _filters.PageSize = pageSize.Value;
        }

        return this;
    }

    public CustomerFilters Build() => _filters;
}