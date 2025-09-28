namespace Vinder.Comanda.WebApi.Controllers;

[ApiController]
[Route("api/v1/customers")]
public sealed class CustomersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync(
        [FromQuery] CustomersFetchParameters request, CancellationToken cancellation)
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
    public async Task<IActionResult> CreateCustomerAsync(
        CreateCustomerRequest request, CancellationToken cancellation)
    {
        var result = await mediator.Send(request, cancellation);

        return result switch
        {
            { IsSuccess: true } =>
                StatusCode(StatusCodes.Status201Created, result.Data),

            // raise error: #COMANDA-ERROR-76A714 (tracking purposes)
            { IsFailure: true } when result.Error == CustomerErrors.CustomerAlreadyExists =>
                StatusCode(StatusCodes.Status409Conflict, result.Error)
        };
    }
}
