using Examples.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Examples.Mocks;

public static class MockFinancialService
{
    public static IEnumerable<FinancialsModel> GetDataForTickers(IEnumerable<string> tickers) => 
        new List<FinancialsModel>
        {
            new FinancialsModel
            {
                Company = "GORP1",
                CurrentRatio = 4,
                DebtToEq = 5,
                Dividend = 2.33m,
                Eps = 3.18,
                Price = 123.22m,
                PriceToEarning = 17
            },new FinancialsModel
            {
                Company = "GORP2",
                CurrentRatio = 33,
                DebtToEq = 11.1,
                Dividend = 5.5m,
                Eps = 3.72,
                Price = 501.99m,
                PriceToEarning = 12.3
            },new FinancialsModel
            {
                Company = "GORP3",
                CurrentRatio = 10,
                DebtToEq = 1,
                Dividend = 0,
                Eps = 5,
                Price = 12.66m,
                PriceToEarning = 55
            }
        };

    public static IEnumerable<RankModel> GetRanksForTickers(IEnumerable<string> tickers)
    {
       var data = new List<RankModel>();

        // Generate sample data
        Random random = new Random();
        for (int i = 1; i <= 10; i++)
        {
            RankModel rank = new RankModel
            {
                Company = $"Company {i}",
                Rank = random.Next(1, 101),
                ValueScore = random.Next(1, 101),
                GrowthScore = random.Next(1, 101),
                MomentumScore = random.Next(1, 101),
                VgmScore = random.Next(1, 101)
            };
            data.Add(rank);
        }

        return data;
    }

    public static byte[] GetExportData(IEnumerable<FinancialsModel> data)
    {
        // Create a new Excel package
        using (var package = new ExcelPackage())
        {
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
}
