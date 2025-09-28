namespace Vinder.Comanda.Infrastructure.IoC.Extensions;

[ExcludeFromCodeCoverage(Justification = "contains only dependency injection registration with no business logic.")]
public static class ValidationExtension
{
    public static void AddValidation(this IServiceCollection services)
    {
        services.AddTransient<IValidator<CreateCustomerRequest>, CustomerCreationValidator>();
        services.AddTransient<IValidator<CreateOwnerRequest>, OwnerCreationValidator>();
    }
}