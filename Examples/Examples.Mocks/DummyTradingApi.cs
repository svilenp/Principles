namespace Examples.Mocks;

public class DummyTradingApi
{
    public void BuyStock(string ticker, double sharesCount)
    {
        throw new NotImplementedException();
    }

    public void SellOrder(string ticker, double sharesCount)
    {
        throw new NotImplementedException();
    }
}
