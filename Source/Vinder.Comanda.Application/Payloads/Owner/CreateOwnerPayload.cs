namespace Vinder.Comanda.Application.Payloads.Owner;

public sealed class CreateOwnerRequest : IRequest<Result<OwnerDetails>>
{
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string UserId { get; init; } = default!;
}