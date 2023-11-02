namespace Examples.After.SOLID.SRP;

public interface ITradeService
{
    void BuyStock(string ticker, double sharesCount);

    void SellStock(string ticker, double sharesCount);
}
