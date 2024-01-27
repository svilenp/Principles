using Examples.Before.SOLID.OCP;
using Examples.Before.SOLID.SRP_ISP;
using Examples.Mocks;
using Examples.Mocks.Interfaces;

namespace Examples.Before.Startup;

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
