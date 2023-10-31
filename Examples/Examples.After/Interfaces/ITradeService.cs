namespace Examples.Before.Interfaces;

public interface ITradeService
{
    void BuyStock(string ticker, double sharesCount);

    void SellStock(string ticker, double sharesCount);
}
