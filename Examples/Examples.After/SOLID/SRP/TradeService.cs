using Examples.Mocks.Interfaces;
using Examples.Before.Interfaces;

namespace Examples.Before.SOLID.SRP;

public class TradeService : ITradeService
{
    private readonly ITradingApi _dummyTradingApi;

    public TradeService(ITradingApi dummyTradingApi)
    {
        _dummyTradingApi = dummyTradingApi;
    }

    /// <summary>
    /// Implementation for buying a stock by stock ticker symbol and shares count (supports fractional shares)
    ///     - it could probably call an external API
    /// * very simplified entry point for illustrating purposes
    /// </summary>
    /// <param name="ticker">A Stock Ticker Symbol</param>
    /// <param name="sharesCount">Shares Count</param>
    public void BuyStock(string ticker, double sharesCount)
    {
        try
        {
            _dummyTradingApi.BuyOrder(ticker, sharesCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to buy {sharesCount} shares of {ticker}: {ex.Message}");
        }
    }

    /// <summary>
    /// Implementation for selling order of a stock by stock ticker symbol and shares count (supports fractional shares)
    ///     - it could probably call an external API
    /// * very simplified for illustrating purposes
    /// </summary>
    /// <param name="ticker">A Stock Ticker Symbol</param>
    /// <param name="sharesCount">Shares Count</param>
    public void SellStock(string ticker, double sharesCount)
    {
        try
        {
            _dummyTradingApi.SellOrder(ticker, sharesCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to sell {sharesCount} shares of {ticker}: {ex.Message}");
        }
    }
}
