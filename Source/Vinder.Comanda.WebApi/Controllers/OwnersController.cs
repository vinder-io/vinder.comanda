namespace Vinder.Comanda.WebApi.Controllers;

[ApiController]
[Route("api/v1/owners")]
public sealed class OwnersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOwnersAsync(
        [FromQuery] OwnersFetchParameters request, CancellationToken cancellation)
    {
        var result = await mediator.Send(request, cancellation);

        // we know the switch here is not strictly necessary since we only handle the success case,
        // but we keep it for consistency with the rest of the codebase and to follow established patterns.
        return result switch
        {
            { IsSuccess: true } => StatusCode(StatusCodes.Status200OK, result.Data),
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateOwnerAsync(
        CreateOwnerRequest request, CancellationToken cancellation)
    {
        var result = await mediator.Send(request, cancellation);

        return result switch
        {
            { IsSuccess: true } =>
                StatusCode(StatusCodes.Status201Created, result.Data),

            // raise error: #COMANDA-ERROR-9DA90 (tracking purposes)
            { IsFailure: true } when result.Error == OwnerErrors.OwnerAlreadyExists =>
                StatusCode(StatusCodes.Status409Conflict, result.Error)
        };
    }
}
