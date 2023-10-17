namespace Examples.Mocks.Interfaces;

public interface ITradingApi
{
    void BuyOrder(string ticker, double sharesCount);
    void SellOrder(string ticker, double sharesCount);
}
