using Examples.Mocks.Interfaces;

namespace Examples.Mocks;

public class DummySmsApi : ISmsApi
{
    public void Send(string message, string phoneNumber, string accountSid)
    {
        Console.WriteLine($"Message: {message} was sent to {phoneNumber}, via SMS Gateway Service Account SID: {accountSid}");
    }
}
