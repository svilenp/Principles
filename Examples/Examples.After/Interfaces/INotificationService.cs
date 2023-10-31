using Examples.Models;

namespace Examples.Before.Interfaces;

public interface INotificationService
{
    Task SendData(IEnumerable<FinancialsModel> data, string email);

    Task SendEmailAlert(string ticker, string email, string action);

    void SendSmsAlert(string ticker, string phoneNumber, string action);
}
