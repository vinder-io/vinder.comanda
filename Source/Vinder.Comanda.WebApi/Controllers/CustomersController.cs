namespace Vinder.Comanda.WebApi.Controllers;

[ApiController]
[Route("api/v1/customers")]
public sealed class CustomersController(IMediator mediator, ILogger<CustomersController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(
        CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        var error = result.Error;

        logger.LogInformation(
            result.IsSuccess
                ? "customer {Email} created successfully."
                : "failed to create customer {Email}. Error: {Code} - {Description}",

            request.Email,
            result.IsSuccess ? null : error.Code,
            result.IsSuccess ? null : error.Description
        );

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
