using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using RazorEngine.Templating;
using Services.Interfaces;
using Services.Models;

namespace Services.Services
{
    public class EmailService : IEmailService
    {
        public string ApplyLayout(string bodyHtml) {
            var templateFilePath = AppDomain.CurrentDomain.BaseDirectory + "EmailTemplates\\EmailTemplate.cshtml";

            var layout = System.IO.File.ReadAllText(templateFilePath);

            return layout.Replace("#RENDERBODY", bodyHtml);
        }
        public void SendRequireAddressValidation(string emailTo, string emailFrom, string name, string address)
        {
            var model = new BasicEmailModel
            {
                Name = name,
                Link = address
            };

            var templateFilePath = AppDomain.CurrentDomain.BaseDirectory + "EmailTemplates\\AddressVerification.cshtml";
            var templateService = new TemplateService();
            var htmlText = ApplyLayout(System.IO.File.ReadAllText(templateFilePath));
            var emailHtmlBody = templateService.Parse(htmlText, model, null, null);

            SendEmail(emailTo, emailFrom, "Address verification required", emailHtmlBody);
        }

        public void SendRequireEmailValidation(string emailTo, string emailFrom, string name, string link)
        {
            var model = new BasicEmailModel
            {
                Name = name,
                Link = link
            };

            var templateFilePath = AppDomain.CurrentDomain.BaseDirectory + "EmailTemplates\\EmailVerification.cshtml";
            var templateService = new TemplateService();
            var htmlText = ApplyLayout(System.IO.File.ReadAllText(templateFilePath));
            var emailHtmlBody = templateService.Parse(htmlText, model, null, null);

            SendEmail(emailTo, emailFrom, "Email verification required", emailHtmlBody);
        }

        public void SendForgotPasswordLink(string emailTo, string emailFrom, string name, string link)
        {
            var model = new BasicEmailModel
            {
                Name = name,
                Link = link
            };

            var templateFilePath = AppDomain.CurrentDomain.BaseDirectory + "EmailTemplates\\ForgotPassword.cshtml";
            var templateService = new TemplateService();
            var htmlText = ApplyLayout(System.IO.File.ReadAllText(templateFilePath));
            var emailHtmlBody = templateService.Parse(htmlText, model, null, null);

            SendEmail(emailTo, emailFrom, "Forgot your password", emailHtmlBody);
        }

        public void SendEmail(string emailTo, string emailFrom, string subject, string body)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(emailTo));
            message.Subject = subject;
            message.Body = body;
            message.From = new MailAddress(emailFrom);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                smtp.Send(message);
            }
        }

        public void SendContactEmail(string emailTo, string emailFrom, string emailName, string emailBody)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(emailTo));
            message.From = new MailAddress(emailFrom);
            message.Subject = "User Contact";
            message.Body = emailName + " has sent the following message: " + emailBody;
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                smtp.Send(message);
            }

        }
    }
}
