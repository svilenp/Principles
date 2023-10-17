using Examples.Interfaces;
using Examples.Mocks;
using Examples.Mocks.Interfaces;
using Examples.SOLID.SRP;

namespace Examples.Before.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<IFinancialDataService, FinancialDataService>();
        services.AddSingleton<ISmsApi, DummySmsApi>();
        services.AddSingleton<ITradingApi, DummyTradingApi>();

        return services;
    }
}
