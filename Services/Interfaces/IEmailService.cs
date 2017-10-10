namespace Services.Interfaces
{
    public interface IEmailService
    {
        void SendRequireAddressValidation(string emailTo, string emailFrom, string name, string link);
        void SendRequireEmailValidation(string emailTo, string emailFrom, string name, string link);
        void SendForgotPasswordLink(string emailTo, string emailFrom, string name, string link);
        void SendEmail(string emailTo, string emailFrom, string subject, string body);
        void SendContactEmail(string emailTo, string emailFrom, string emailName, string emailBody);
    }
}
