using Examples.Models;

namespace Examples.Before.Interfaces;

public interface IFinancialExportService
{
    byte[] ExportData(IEnumerable<FinancialsModel> data);
}
