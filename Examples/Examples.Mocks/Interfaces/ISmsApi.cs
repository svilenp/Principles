namespace Examples.Mocks.Interfaces;

public interface ISmsApi
{
    void Send(string message, string phoneNumber, string accountSid);
}
