using Examples.Mocks;
using Examples.Models.Models;
using OfficeOpenXml;

namespace Examples.After.SOLID.OCP;

public class ExportBaseHelper : IExportBaseHelper
{
    public ExcelWorksheet BuildSheet(ExcelPackage package)
    {
        var worksheet = package.Workbook.Worksheets.Add("ExportedData");

        worksheet.Cells[1, 1].Value = "Order ID";
        worksheet.Cells[1, 2].Value = "Product";
        worksheet.Cells[1, 3].Value = "Quantity";

        return worksheet;
    }

    public void AddFooterSection(ExcelWorksheet worksheet)
    {
        // Define and format the footer section
        worksheet.Cells["A10"].Value = "Footer Information";
        worksheet.Cells["A10:C10"].Style.Font.Bold = true;
    }

    public void AddHeaderSection(ExcelWorksheet worksheet)
    {
        // Define and format the header section
        worksheet.Cells["A1:C1"].Style.Font.Bold = true;
        worksheet.Cells["A1:C1"].AutoFilter = true;
    }

    public void CollectOrdersData(ExcelWorksheet worksheet)
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

    public void CollectUsersData(ExcelWorksheet worksheet)
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

    public void SetCellValue(ExcelWorksheet worksheet)
    {
        // Set cell values, for example:
        worksheet.Cells["A2"].Value = "Sample Value 1";
        worksheet.Cells["B2"].Value = "Sample Value 2";
    }
}
