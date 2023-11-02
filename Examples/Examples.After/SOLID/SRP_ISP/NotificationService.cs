using Examples.Models;
using System.Text;
using System.Net;
using System.Net.Mail;
using Examples.Mocks.Interfaces;
using Examples.After.SOLID.SRP;

namespace Examples.After.SOLID.SRP;

public class NotificationService : INotificationService
{
    private readonly ISmsApi _dummySmsApi;

    public NotificationService(ISmsApi dummySmsApi)
    {
        _dummySmsApi = dummySmsApi;
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
    public async Task SendEmailAlert(string ticker, string email, string action)
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
                    Subject = $"Alert for {ticker}",
                    Body = $"{action} notification for {ticker}."
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
    public void SendSmsAlert(string ticker, string phoneNumber, string action)
    {
        try
        {
            // Your SMS Gateway Service Account SID 
            string accountSid = "your_account_sid";

            string message = $"{action} notification for {ticker}.";

            // Create and send the SMS message
            _dummySmsApi.Send(message, phoneNumber, accountSid);

            Console.WriteLine("SMS alert sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send SMS alert: {ex.Message}");
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
