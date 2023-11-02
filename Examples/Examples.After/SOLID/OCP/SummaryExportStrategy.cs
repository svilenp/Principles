using OfficeOpenXml;

namespace Examples.After.SOLID.OCP;

public class SummaryExportStrategy : IExportStrategy
{
    private readonly IExportBaseHelper _exportHelper;

    public SummaryExportStrategy(IExportBaseHelper exportHelper)
    {
        _exportHelper = exportHelper;
    }

    public Stream Export()
    {
        using var package = new ExcelPackage();
        var worksheet = _exportHelper.BuildSheet(package);

        _exportHelper.SetCellValue(worksheet);
        AddSummary(worksheet);

        var stream = new MemoryStream();
        package.SaveAs(stream);
        return stream;
    }

    private static void AddSummary(ExcelWorksheet worksheet)
    {
        // Add a summary section
        worksheet.Cells["A20"].Value = "Summary";
        worksheet.Cells["A20:C20"].Style.Font.Bold = true;
    }
}
