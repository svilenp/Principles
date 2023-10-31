using Examples.Models;

namespace Examples.Before.Interfaces;

public interface IFinancialDataService
{
    IEnumerable<FinancialsModel> GetMetrics(IEnumerable<string> tickers);

    IEnumerable<RankModel> GetRanks(IEnumerable<string> tickers);
}
