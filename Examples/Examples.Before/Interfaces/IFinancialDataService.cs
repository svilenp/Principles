using Examples.Models;

namespace Examples.Interfaces;

public interface IFinancialDataService
{
    IEnumerable<FinancialsModel> GetMetrics(IEnumerable<string> tickers);

    IEnumerable<RankModel> GetRanks(IEnumerable<string> tickers);

    byte[] ExportData(IEnumerable<FinancialsModel> data);

    Task SendData(IEnumerable<FinancialsModel> data, string email);

    Task SendEmailAlert(string ticker, string email);

    void SendSmsAlert(string ticker, string phoneNumber);

    void BuyStock(string ticker, double sharesCount);

    void SellStock(string ticker, double sharesCount);
}
