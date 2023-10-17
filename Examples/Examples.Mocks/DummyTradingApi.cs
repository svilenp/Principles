using Examples.Mocks.Interfaces;

namespace Examples.Mocks;

public class DummyTradingApi : ITradingApi
{
    public void BuyOrder(string ticker, double sharesCount)
    {
        throw new NotImplementedException();
    }

    public void SellOrder(string ticker, double sharesCount)
    {
        throw new NotImplementedException();
    }
}
