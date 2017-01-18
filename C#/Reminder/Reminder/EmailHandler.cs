using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Reminder
{
    //TODO: Add other email clients, such as ( yahoo, outlook )
    class EmailHandler
    {
        // Email address that the reminders will be sent from
        private static readonly MailAddress from = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromEmailDisplayName"]);
        // Email address that the reminders will be sent to
        private static readonly MailAddress to = new MailAddress(ConfigurationManager.AppSettings["ToEmail"]);
        
        // Password to the 'from' email address so that program can login and send email.
        string pw = "";

        /// <summary>
        /// Email subject
        /// </summary>
        public string Subject_
        {
            get; set;
        }
        /// <summary>
        /// Email body
        /// </summary>
        public string Body_
        {
            get; set;
        }

        public EmailHandler()
        {
            try
            {
                // You can hardcode email's password here
                pw = FileHandler.ReadFile(ConfigurationManager.AppSettings["FromEmailLoginPWFileLocation"])[0];
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to get password for email.\n\n" + ex.Message);
            }
            
        }

        /// <summary>
        /// Sends an email
        /// </summary>
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

        /// <summary>
        /// Sends an email with error details
        /// </summary>
        /// <param name="ex">Exception that occurs</param>
        public static void SendErrorEmail(Exception ex)
        {
            EmailHandler em = new EmailHandler();
            em.Subject_ = "Error from Reminder application";
            em.Body_ = ex.Source + "\n\n" + ex.TargetSite + "\n\n" + ex.Message + "\n\n" + ex.StackTrace + "\n\n";

            em.SendEmail();
        }
    }
}
