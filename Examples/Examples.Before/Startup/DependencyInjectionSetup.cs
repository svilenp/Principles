using Examples.After.SOLID.OCP;
using Examples.After.SOLID.SRP;
using Examples.Mocks;
using Examples.Mocks.Interfaces;

namespace Examples.After.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<IFinancialDataService, FinancialDataService>();
        services.AddScoped<IExportService, ExportService>();

        services.AddSingleton<ISmsApi, DummySmsApi>();
        services.AddSingleton<ITradingApi, DummyTradingApi>();

        return services;
    }
}
