namespace Examples.Models;

public class FinancialsModel : CompanyDataModel
{
    public decimal Price { get; set; }
    public decimal TargetPrice { get; set; }
    public double Roe { get; set; }
    public double Roa { get; set; }
    public double CurrentRatio { get; set; }
    public double DebtToEq { get; set; }
    public double PriceToEarning { get; set; }
    public double PriceToBook { get; set; }
    public decimal Dividend { get; set; }
    public double Peg { get; set; }
    public double Eps { get; set; }
}
