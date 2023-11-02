using OfficeOpenXml;

namespace Examples.After.SOLID.OCP;

public class FullExportStrategy : IExportStrategy
{
    private readonly IExportBaseHelper _exportHelper;

    public FullExportStrategy(IExportBaseHelper exportHelper)
    {
        _exportHelper = exportHelper;
    }

    public Stream Export()
    {
        using var package = new ExcelPackage();
        var worksheet = _exportHelper.BuildSheet(package);

        _exportHelper.SetCellValue(worksheet);
        _exportHelper.CollectOrdersData(worksheet);
        _exportHelper.CollectUsersData(worksheet);
        _exportHelper.AddHeaderSection(worksheet);
        _exportHelper.AddFooterSection(worksheet);
        BuildCustomSection(worksheet);
        BuildTotalsSection(worksheet);
        ApplySpecialStyling(worksheet);

        var stream = new MemoryStream();
        package.SaveAs(stream);

        return stream;
    }

    private static void BuildCustomSection(ExcelWorksheet worksheet)
    {
        // Implement custom section logic, e.g., adding images or custom data
        worksheet.Cells["A15"].Value = "Custom Section";
        worksheet.Cells["A15:C15"].Style.Font.Bold = true;
    }

    private static void BuildTotalsSection(ExcelWorksheet worksheet)
    {
        // Calculate and add totals section, e.g., summing up values
        worksheet.Cells["A12"].Value = "Totals";
        worksheet.Cells["B12"].Formula = "SUM(B2:B10)";
        worksheet.Cells["C12"].Formula = "SUM(C2:C10)";
    }

    private static void ApplySpecialStyling(ExcelWorksheet worksheet)
    {
        // Apply special styling, such as colors and borders
        worksheet.Cells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        worksheet.Cells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
    }
}
