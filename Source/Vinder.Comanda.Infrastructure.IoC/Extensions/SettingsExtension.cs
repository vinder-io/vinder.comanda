namespace Vinder.Comanda.Infrastructure.IoC.Extensions;

[ExcludeFromCodeCoverage(Justification = "contains only dependency injection registration with no business logic.")]
public static class SettingsExtension
{
    public static ISettings ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration
            .GetSection("Settings")
            .Get<Settings>()!;

        services.AddSingleton<ISettings>(settings);

        return settings;
    }
}