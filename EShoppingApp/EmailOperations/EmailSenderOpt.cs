using System.Net;
using System.Net.Mail;
using EShoppingApp.EmailOperations.Interfaces;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EShoppingApp.EmailOperations
{
    public class EmailSenderOpt : IEmailSenderOpt
    {
        public async Task SendEmailAsync(string emailToAddress, string subject, string body)
        {
            var emailFromAddress = "huseyn.hasanli@code.edu.az";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailFromAddress);
            mail.To.Add(emailToAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(emailFromAddress, "wavc jtmj pzpn znah"),
                EnableSsl = true,
            };
            client.SendAsync(mail, null);

        }
    }
}
