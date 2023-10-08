using Examples.Interfaces;
using Examples.SOLID.SRP;

namespace Examples.Before.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<IFinancialDataService, FinancialDataService>();

        return services;
    }
}
