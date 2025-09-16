using Vinder.Comanda.Application.Handlers.Customer;

namespace Vinder.Comanda.Infrastructure.IoC.Extensions;

[ExcludeFromCodeCoverage(Justification = "only contains dependency injection registration with no business logic")]
public static class MediatorExtension
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<CreateCustomerHandler>();
        });
    }
}