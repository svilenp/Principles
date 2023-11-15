using Examples.After.SOLID.DIP;
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
        services.AddScoped<IFinancialExportService, FinancialExportService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<ITradeService, TradeService>();
        services.AddScoped<ISortingAlgorithmService, QuickSortService>();
        services.AddScoped<IExportBaseHelper, ExportBaseHelper>();

        services.AddSingleton<ISmsApi, DummySmsApi>();
        services.AddSingleton<ITradingApi, DummyTradingApi>();

        return services;
    }
}
