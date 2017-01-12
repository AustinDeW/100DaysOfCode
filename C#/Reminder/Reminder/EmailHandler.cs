using System;
using System.Net;
using System.Net.Mail;

namespace Reminder
{
    class EmailHandler
    {
        private static readonly MailAddress from = new MailAddress("austinsbotmail@gmail.com", "Austin's Bot");
        private static readonly MailAddress to = new MailAddress("austinrdewitt1@gmail.com");

        const string pw = "Warhawk1!1";
        public string Subject_
        {
            get; set;
        }
        public string Body_
        {
            get; set;
        }

        public EmailHandler() { }

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
