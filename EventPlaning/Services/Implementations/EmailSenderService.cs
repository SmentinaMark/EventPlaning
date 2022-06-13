using EventPlaning.Services.Interfaces;
using System.Net.Mail;
using System.Text;

namespace EventPlaning.Services.Implementations
{
    public class EmailSenderService : IEmailSender
    {
        public void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MailMessage();

            emailMessage.To.Add(email);
            emailMessage.Subject = subject;
            emailMessage.Body = message;
            emailMessage.From = new MailAddress("marksmentina@gmail.com", "EventPlanning", Encoding.UTF8);
            emailMessage.IsBodyHtml = false;

            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.UseDefaultCredentials = true;
                client.EnableSsl = true;

                client.Credentials = new System.Net.NetworkCredential("marksmentina@gmail.com", "bncdizecmlbgkyht");
                client.DeliveryFormat = SmtpDeliveryFormat.International;
                client.Send(emailMessage);
            }
        }
    }
}

