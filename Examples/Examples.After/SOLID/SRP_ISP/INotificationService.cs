using Examples.Models;

namespace Examples.After.SOLID.SRP;

public interface INotificationService
{
    Task SendData(IEnumerable<FinancialsModel> data, string email);

    Task SendEmailAlert(string ticker, string email, string action);

    void SendSmsAlert(string ticker, string phoneNumber, string action);
}
