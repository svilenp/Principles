using Examples.Models;

namespace Examples.After.SOLID.SRP;

public interface IFinancialExportService
{
    byte[] ExportData(IEnumerable<FinancialsModel> data);
}
