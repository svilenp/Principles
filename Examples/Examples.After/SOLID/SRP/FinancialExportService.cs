using Examples.Models;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using Examples.Before.Interfaces;

namespace Examples.Before.SOLID.SRP;

public class FinancialExportService : IFinancialExportService
{
    /// <summary>
    /// Contais a logic to generate an export document based on the financial data for 
    /// a list of companies
    /// </summary>
    /// <param name="data">A Collection of Financial Data</param>
    /// <returns>Bytes array of the document data</returns>
    public byte[] ExportData(IEnumerable<FinancialsModel> data)
    {
        // Create a new Excel package
        using var package = new ExcelPackage();
        // Add a worksheet to the Excel package
        var worksheet = package.Workbook.Worksheets.Add("MyData");

        // Define the columns in the Excel worksheet
        worksheet.Cells["A1"].Value = "Company";
        worksheet.Cells["B1"].Value = "Price";
        worksheet.Cells["C1"].Value = "Target Price";
        worksheet.Cells["D1"].Value = "ROE";
        worksheet.Cells["E1"].Value = "ROA";
        worksheet.Cells["F1"].Value = "Current Ratio";
        worksheet.Cells["G1"].Value = "Debt To Equity";
        worksheet.Cells["H1"].Value = "Price To Earning";
        worksheet.Cells["I1"].Value = "Price To Book";
        worksheet.Cells["J1"].Value = "Dividend";
        worksheet.Cells["K1"].Value = "PEG";
        worksheet.Cells["L1"].Value = "EPS";

        // Apply formatting to the header row
        using (var range = worksheet.Cells["A1:L1"])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
        }

        // Fill data starting from the second row
        int row = 2;
        foreach (var item in data)
        {
            worksheet.Cells[$"A{row}"].Value = item.Company;
            worksheet.Cells[$"B{row}"].Value = item.Price;
            worksheet.Cells[$"C{row}"].Value = item.TargetPrice;
            worksheet.Cells[$"D{row}"].Value = item.Roe;
            worksheet.Cells[$"E{row}"].Value = item.Roa;
            worksheet.Cells[$"F{row}"].Value = item.CurrentRatio;
            worksheet.Cells[$"G{row}"].Value = item.DebtToEq;
            worksheet.Cells[$"H{row}"].Value = item.PriceToEarning;
            worksheet.Cells[$"I{row}"].Value = item.PriceToBook;
            worksheet.Cells[$"J{row}"].Value = item.Dividend;
            worksheet.Cells[$"K{row}"].Value = item.Peg;
            worksheet.Cells[$"L{row}"].Value = item.Eps;

            row++;
        }

        // Auto-fit columns for better appearance
        worksheet.Cells.AutoFitColumns();

        // Save the Excel package to a MemoryStream
        var stream = new MemoryStream(package.GetAsByteArray());

        // Return the MemoryStream as bytes
        return stream.ToArray();
    }
}
