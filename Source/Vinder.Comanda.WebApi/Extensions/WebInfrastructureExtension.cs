namespace Vinder.Comanda.WebApi.Extensions;

[ExcludeFromCodeCoverage(Justification = "contains only web infrastructure configuration with no business logic.")]
public static class WebInfrastructureExtension
{
    public static void AddWebComposition(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();
        services.AddCorsConfiguration();
        services.AddOpenApi();
    }
}