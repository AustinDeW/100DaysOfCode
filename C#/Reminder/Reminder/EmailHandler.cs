using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Reminder
{
    class EmailHandler
    {
        private static readonly MailAddress from = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromEmailDisplayName"]);
        private static readonly MailAddress to = new MailAddress(ConfigurationManager.AppSettings["ToEmail"]);

        string pw = "";
        public string Subject_
        {
            get; set;
        }
        public string Body_
        {
            get; set;
        }

        public EmailHandler() { pw = FileHandler.ReadFile(@ConfigurationManager.AppSettings["FromEmailLoginPW"])[0]; }

        public void SendEmail()
        {
            Console.Write($"Sending email to {to}...");
            SmtpClient mailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from.Address, pw),
                Timeout = 20000
            };

            using (var message = new MailMessage(from, to)
            {
                Subject = Subject_,
                Body = Body_
            })
            {
                mailClient.Send(message);
            }

            Console.WriteLine("done sending email.");
        }
    }
}
