namespace Vinder.Comanda.Application.Handlers.Owner;

public sealed class FetchOwnersHandler(IOwnerRepository repository) :
    IRequestHandler<OwnersFetchParameters, Result<Pagination<OwnerDetails>>>
{
    public async Task<Result<Pagination<OwnerDetails>>> Handle(
        OwnersFetchParameters request, CancellationToken cancellationToken)
    {
        var filters = OwnerMapper.AsFilters(request);

        var owners = await repository.GetOwnersAsync(filters, cancellationToken);
        var total = await repository.CountAsync(filters, cancellationToken);

        var pagination = new Pagination<OwnerDetails>
        {
            Items = [.. owners.Select(owner => OwnerMapper.AsResponse(owner))],
            Total = (int)total,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
        };

        return Result<Pagination<OwnerDetails>>.Success(pagination);
    }
}