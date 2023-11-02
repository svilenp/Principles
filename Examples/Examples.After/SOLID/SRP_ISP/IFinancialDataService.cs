using Examples.Models;

namespace Examples.After.SOLID.SRP;

public interface IFinancialDataService
{
    IEnumerable<FinancialsModel> GetMetrics(IEnumerable<string> tickers);

    IEnumerable<RankModel> GetRanks(IEnumerable<string> tickers);
}
