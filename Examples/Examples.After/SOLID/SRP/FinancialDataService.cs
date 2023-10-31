using Examples.Mocks;
using Examples.Models;
using Examples.Before.Interfaces;

namespace Examples.Before.SOLID.SRP;

public class FinancialDataService : IFinancialDataService
{
    /// <summary>
    /// This method is supposed to collect financial data, probably through a public API, for a given
    /// collection of stock symbols
    /// It also applies a business logic to generate some financial ratios based on the data coming from the 
    /// external API.
    /// </summary>
    /// <param name="tickers">A Collection of Stock Ticker Symbols</param>
    /// <returns>Financial Data Collection</returns>
    public IEnumerable<FinancialsModel> GetMetrics(IEnumerable<string> tickers) => MockFinancialService.GetDataForTickers(tickers);

    /// <summary>
    /// This method is supposed to collect financial statistics, probably through a public API, for a given
    /// collection of stock symbols
    /// It also applies a business logic to generate prediction scores(a.k.a.ranks) based on the data coming from the
    /// external API.
    /// </summary>
    /// <param name="tickers">A Collection of Stock Ticker Symbols</param>
    /// <returns>Ranks Collection</returns>
    public IEnumerable<RankModel> GetRanks(IEnumerable<string> tickers) => MockFinancialService.GetRanksForTickers(tickers);
}
