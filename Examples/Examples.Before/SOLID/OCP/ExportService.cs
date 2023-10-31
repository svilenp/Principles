using Examples.Before.Interfaces;
using Examples.Mocks;
using Examples.Models.Models;
using OfficeOpenXml;

using static Examples.Models.Static.Enums;

namespace Examples.Before.SOLID.OCP;

public class ExportService : IExportService
{
    public Stream Export(ExportType exportType)
    {
        using (var package = new ExcelPackage())
        {
            var worksheet = BuildSheet(package);

            switch (exportType)
            {
                case ExportType.Full:
                    SetCellValue(worksheet);
                    CollectOrdersData(worksheet);
                    CollectUsersData(worksheet);
                    AddHeaderSection(worksheet);
                    AddFooterSection(worksheet);
                    BuildCustomSection(worksheet);
                    BuildTotalsSection(worksheet);
                    ApplySpecialStyling(worksheet);
                    break;

                case ExportType.Limited:
                    SetCellValue(worksheet);
                    CollectOrdersData(worksheet);
                    CollectUsersData(worksheet);
                    AddHeaderSection(worksheet);
                    AddFooterSection(worksheet);
                    break;

                case ExportType.Summary:
                    SetCellValue(worksheet);
                    AddSummary(worksheet);
                    break;

                default:
                    throw new ArgumentException("Invalid export type");
            }

            var stream = new MemoryStream();
            package.SaveAs(stream);
            return stream;
        }
    }

    private ExcelWorksheet BuildSheet(ExcelPackage package)
    {
        var worksheet = package.Workbook.Worksheets.Add("ExportedData");

        worksheet.Cells[1, 1].Value = "Order ID";
        worksheet.Cells[1, 2].Value = "Product";
        worksheet.Cells[1, 3].Value = "Quantity";

        return worksheet;
    }

    private void SetCellValue(ExcelWorksheet worksheet)
    {
        // Set cell values, for example:
        worksheet.Cells["A2"].Value = "Sample Value 1";
        worksheet.Cells["B2"].Value = "Sample Value 2";
    }

    private void CollectOrdersData(ExcelWorksheet worksheet)
    {
        // Fetch order data from a database or other source
        List<Order> orders = MockOrdersService.GetOrdersFromDatabase();

        // Write order data to the worksheet
        int row = 2; // Starting row
        foreach (var order in orders)
        {
            worksheet.Cells[row, 1].Value = order.OrderId;
            worksheet.Cells[row, 2].Value = order.Product;
            worksheet.Cells[row, 3].Value = order.Quantity;
            row++;
        }
    }

    private void CollectUsersData(ExcelWorksheet worksheet)
    {
        // Fetch user data from a database or other source
        var custommers = MockOrdersService.GetCustommersFromDatabase();

        // Write user data to the worksheet
        int row = 2; // Starting row
        foreach (var custommer in custommers)
        {
            worksheet.Cells[row, 1].Value = custommer.CustommerId;
            worksheet.Cells[row, 2].Value = custommer.UserName;
            worksheet.Cells[row, 3].Value = custommer.Email;
            row++;
        }
    }

    private void AddHeaderSection(ExcelWorksheet worksheet)
    {
        // Define and format the header section
        worksheet.Cells["A1:C1"].Style.Font.Bold = true;
        worksheet.Cells["A1:C1"].AutoFilter = true;
    }

    private void AddFooterSection(ExcelWorksheet worksheet)
    {
        // Define and format the footer section
        worksheet.Cells["A10"].Value = "Footer Information";
        worksheet.Cells["A10:C10"].Style.Font.Bold = true;
    }

    private void BuildCustomSection(ExcelWorksheet worksheet)
    {
        // Implement custom section logic, e.g., adding images or custom data
        worksheet.Cells["A15"].Value = "Custom Section";
        worksheet.Cells["A15:C15"].Style.Font.Bold = true;
    }

    private void BuildTotalsSection(ExcelWorksheet worksheet)
    {
        // Calculate and add totals section, e.g., summing up values
        worksheet.Cells["A12"].Value = "Totals";
        worksheet.Cells["B12"].Formula = "SUM(B2:B10)";
        worksheet.Cells["C12"].Formula = "SUM(C2:C10)";
    }

    private void ApplySpecialStyling(ExcelWorksheet worksheet)
    {
        // Apply special styling, such as colors and borders
        worksheet.Cells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        worksheet.Cells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
    }

    private void AddSummary(ExcelWorksheet worksheet)
    {
        // Add a summary section
        worksheet.Cells["A20"].Value = "Summary";
        worksheet.Cells["A20:C20"].Style.Font.Bold = true;
    }
}

