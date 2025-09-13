namespace Vinder.Comanda.Common.Configurations;

public sealed class Settings : ISettings
{
    public DatabaseSettings Database { get; set; } = default!;
}