using Examples.Before.Interfaces;
using Examples.Before.SOLID.SRP;
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
        services.AddScoped<IFinancialExportService, FinancialExportService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<ITradeService, TradeService>();

        services.AddSingleton<ISmsApi, DummySmsApi>();
        services.AddSingleton<ITradingApi, DummyTradingApi>();

        return services;
    }
}
