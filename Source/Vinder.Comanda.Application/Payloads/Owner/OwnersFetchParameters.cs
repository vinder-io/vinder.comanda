namespace Vinder.Comanda.Application.Payloads.Owner;

public sealed record OwnersFetchParameters : IRequest<Result<Pagination<OwnerDetails>>>
{
    public string? Id { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? UserId { get; init; }
    public string? SubscriptionStatus { get; init; }
    public bool? IsDeleted { get; init; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 60;
}