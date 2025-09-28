namespace Vinder.Comanda.Application.Mappers;

public static class OwnerMapper
{
    public static Owner AsOwner(CreateOwnerRequest request)
    {
        Owner owner = new();
        Subscription subscription = new();

        Identity identity = new(request.UserId, request.Email);

        subscription.SetStatus(SubscriptionStatus.None);

        owner.SetName(request.Name);
        owner.SetSubscription(subscription);
        owner.SetIdentity(identity);

        return owner;
    }

    public static OwnerFilters AsFilters(OwnersFetchParameters parameters)
    {
        var filters = OwnerFilters.WithSpecifications()
            .WithId(parameters.Id)
            .WithName(parameters.Name)
            .WithUserId(parameters.UserId)
            .WithEmail(parameters.Email)
            .WithIsDeleted(parameters.IsDeleted)
            .WithPageNumber(parameters.PageNumber)
            .WithPageSize(parameters.PageSize);

        if (!string.IsNullOrWhiteSpace(parameters.SubscriptionStatus) &&
            Enum.TryParse<SubscriptionStatus>(parameters.SubscriptionStatus, ignoreCase: true, out var status))
        {
            filters.WithSubscriptionStatus(status);
        }

        return filters.Build();
    }

    public static OwnerDetails AsResponse(Owner owner) => new()
    {
        Id = owner.Id,
        Name = owner.Name,
        Email = owner.Identity.Email,
        SubscriptionStatus = owner.Subscription.Status.ToString().ToLower(),
        HasSubscription = owner.Subscription.Status != SubscriptionStatus.None,
        IsSubscriptionActive = owner.Subscription.Status == SubscriptionStatus.Active,
    };
}