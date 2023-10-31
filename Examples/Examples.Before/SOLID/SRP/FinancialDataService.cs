using Examples.Mocks;
using Examples.Models;
using System.Text;
using System.Net;
using System.Net.Mail;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using Examples.Mocks.Interfaces;
using Examples.Before.Interfaces;

namespace Examples.Before.SOLID.SRP;

public class FinancialDataService : IFinancialDataService
{
    private readonly ISmsApi _dummySmsApi;
    private readonly ITradingApi _dummyTradingApi;

    public FinancialDataService(ISmsApi dummySmsApi, ITradingApi dummyTradingApi)
    {
        _dummySmsApi = dummySmsApi;
        _dummyTradingApi = dummyTradingApi;
    }

    /// <summary>
    /// This method is supposed to collect financial data, probably through a public API, for a given
    /// collection of stock symbols
    /// It also applies a business logic to generate some financial ratios based on the data coming from the 
    /// external API.
    /// </summary>
    /// <param name="tickers">A Collection of Stock Ticker Symbols</param>
    /// <returns>Financial Data Collection</returns>
    public IEnumerable<FinancialsModel> GetMetrics(IEnumerable<string> tickers) => MockFinancialService.GetDataForTickers(tickers);

    /// <summary>
    /// This method is supposed to collect financial statistics, probably through a public API, for a given
    /// collection of stock symbols
    /// It also applies a business logic to generate prediction scores(a.k.a.ranks) based on the data coming from the
    /// external API.
    /// </summary>
    /// <param name="tickers">A Collection of Stock Ticker Symbols</param>
    /// <returns>Ranks Collection</returns>
    public IEnumerable<RankModel> GetRanks(IEnumerable<string> tickers) => MockFinancialService.GetRanksForTickers(tickers);

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

    /// <summary>
    /// Send row data for a collection of stocks over some communication channel (e.g. email)
    /// </summary>
    /// <param name="data">A collection of financial data</param>
    /// <param name="email">The email address to the receiver of the data</param>
    public async Task SendData(IEnumerable<FinancialsModel> data, string email)
    {
        try
        {
            // Create a CSV file from the data
            string csvContent = GenerateCsvFromData(data);

            // Configure the SMTP client
            using (var client = new SmtpClient("smtp.example.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential("principles@livethecode.com", "s3cur3dP@s$W0rd!");
                client.EnableSsl = true;

                var message = new MailMessage
                {
                    From = new MailAddress("principles@livethecode.com"),
                    Subject = "Financial Data Report",
                    Body = "Please find attached the financial data report in CSV format."
                };

                message.To.Add(email);

                // Attach the CSV file
                var attachment = new Attachment(new MemoryStream(Encoding.UTF8.GetBytes(csvContent)), "financial_data.csv", "text/csv");
                message.Attachments.Add(attachment);

                // Send the email
                await client.SendMailAsync(message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email: {ex.Message}");
        }
    }

    /// <summary>
    /// Send a notification via email for a given stock, triggered by an event 
    /// (probably a price target reached, or whatever...)
    /// </summary>
    /// <param name="tickers">A collection of stock ticker symbols</param>
    /// <param name="email">The email address to the receiver of the alert</param>
    public async Task SendEmailAlert(string ticker, string email)
    {
        try
        {
            // Configure the SMTP client
            using (var client = new SmtpClient("smtp.example.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential("principles@livethecode.com", "s3cur3dP@s$W0rd!");
                client.EnableSsl = true;

                // Create an email message
                var message = new MailMessage
                {
                    From = new MailAddress("your_email@example.com"),
                    Subject = $"Price Alert for {ticker}",
                    Body = $"The price of {ticker} has reached your specified alert threshold."
                };

                message.To.Add(email);

                // Send the email
                await client.SendMailAsync(message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email alert: {ex.Message}");
        }
    }

    /// <summary>
    /// Send a notification via SMS for a given stock, triggered by an event 
    /// (probably a price target reached, or whatever...)
    /// </summary>
    /// <param name="ticker">A stock ticker symbol</param>
    /// <param name="phoneNumber">The phone number address to the receiver of the alert</param>
    public void SendSmsAlert(string ticker, string phoneNumber)
    {
        try
        {
            // Your SMS Gateway Service Account SID 
            string accountSid = "your_account_sid";

            string message = $"Price Alert for {ticker}: The price has reached your specified threshold.";

            // Create and send the SMS message
            _dummySmsApi.Send(message, phoneNumber, accountSid);

            Console.WriteLine("SMS alert sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send SMS alert: {ex.Message}");
        }
    }

    /// <summary>
    /// Implementation for buying a stock by stock ticker symbol and shares count (supports fractional shares)
    ///     - it could probably call an external API
    /// * very simplified entry point for illustrating purposes
    /// </summary>
    /// <param name="ticker">A Stock Ticker Symbol</param>
    /// <param name="sharesCount">Shares Count</param>
    public void BuyStock(string ticker, double sharesCount)
    {
        try
        {
            _dummyTradingApi.BuyOrder(ticker, sharesCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to buy {sharesCount} shares of {ticker}: {ex.Message}");
        }
    }

    /// <summary>
    /// Implementation for selling order of a stock by stock ticker symbol and shares count (supports fractional shares)
    ///     - it could probably call an external API
    /// * very simplified for illustrating purposes
    /// </summary>
    /// <param name="ticker">A Stock Ticker Symbol</param>
    /// <param name="sharesCount">Shares Count</param>
    public void SellStock(string ticker, double sharesCount)
    {
        try
        {
            _dummyTradingApi.SellOrder(ticker, sharesCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to sell {sharesCount} shares of {ticker}: {ex.Message}");
        }
    }

    private string GenerateCsvFromData(IEnumerable<FinancialsModel> data)
    {
        var csv = new StringBuilder();
        csv.AppendLine("Company,Price,TargetPrice,Roe,Roa,CurrentRatio,DebtToEq,PriceToEarning,PriceToBook,Dividend,Peg,Eps");

        foreach (var item in data)
        {
            csv.AppendLine($"{item.Company},{item.Price},{item.TargetPrice},{item.Roe},{item.Roa},{item.CurrentRatio},{item.DebtToEq},{item.PriceToEarning},{item.PriceToBook},{item.Dividend},{item.Peg},{item.Eps}");
        }

        return csv.ToString();
    }
}
