namespace Vinder.Comanda.Infrastructure.IoC.Extensions;

[ExcludeFromCodeCoverage(Justification = "contains only dependency injection registration with no business logic.")]
public static class ServicesExtension
{
    public static void AddInfrastructure(this IServiceCollection services, ISettings settings)
    {
        services.AddDataPersistence(settings);
    }
}