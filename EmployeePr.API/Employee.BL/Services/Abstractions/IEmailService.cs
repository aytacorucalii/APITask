namespace EmployeePr.BL.Services.Abstractions;

public interface IEmailService
{
    void SendWelcome(string toUser);
    void SendConfirmEmail(string toUser, string confirmUrl);
}
