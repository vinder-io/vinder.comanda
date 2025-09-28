namespace Vinder.Comanda.Application.Handlers.Owner;

public sealed class OwnerCreationHandler(IOwnerRepository repository) :
    IRequestHandler<CreateOwnerRequest, Result<OwnerDetails>>
{
    public async Task<Result<OwnerDetails>> Handle(
        CreateOwnerRequest request, CancellationToken cancellationToken)
    {
        var filters = OwnerFilters.WithSpecifications()
            .WithEmail(request.Email)
            .Build();

        var matchingOwners = await repository.GetOwnersAsync(filters, cancellationToken);
        var existingOwner = matchingOwners.FirstOrDefault();

        if (existingOwner is not null)
        {
            // when owner already exists raise error: #COMANDA-ERROR-9DA90 (comment only for tracking purposes)
            return Result<OwnerDetails>.Failure(OwnerErrors.OwnerAlreadyExists);
        }

        var owner = OwnerMapper.AsOwner(request);
        var result = await repository.InsertAsync(owner, cancellationToken);

        return Result<OwnerDetails>.Success(OwnerMapper.AsResponse(result));
    }
}