using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Reminder
{
    //TODO: Add other email clients, such as ( yahoo, outlook )..done..needs to be tested
    class EmailHandler
    {
        // Email address that the reminders will be sent from
        private static readonly MailAddress from = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromEmailDisplayName"]);
        // Email address that the reminders will be sent to
        private static readonly MailAddress to = new MailAddress(ConfigurationManager.AppSettings["ToEmail"]);
        
        // Password to the 'from' email address so that program can login and send email.
        string pw = "";

        struct Host
        {
            public string EmailClient;
            public string EmailSMTPHost;
            public Host(string client, string host)
            {
                EmailClient = client;
                EmailSMTPHost = host;
            }
        }

        // Email subject
        public string Subject_
        {
            get; set;
        }

        // Email body
        public string Body_
        {
            get; set;
        }

        // Email host
        public string Host_
        {
            get
            {
                Host[] hosts = new Host[3]  //"smtp.gmail.com", // "smtp.mail.yahoo.com", "smtp.live.com"
                {
                    new Host("@gmail.com","smtp.gmail.com"),
                    new Host("@yahoo.com","smtp.mail.yahoo.com"),
                    new Host("@hotmail.com","smtp.live.com")
                };

                string host = "";
                for(int i = 0; i < hosts.Length; i++)
                {
                    if (from.Address.Contains(hosts[i].EmailClient))
                    {
                        host = hosts[i].EmailSMTPHost;
                        break;
                    }
                }
                return host;
            }
            set { }
        }

        public EmailHandler()
        {
            try
            {
                // You can hardcode email's password here
                pw = FileHandler.ReadFile(ConfigurationManager.AppSettings["ReminderDataFileLocation"] + "Other.txt")[0];
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to get password for email.\n\n" + ex.Message);
            }
        }

        public static void SendEmail(string subject, string body)
        {
            EmailHandler em = new EmailHandler();
            em.Subject_ = subject;
            em.Body_ = body;
            em.SendEmail();
        }

        /// <summary>
        /// Sends an email
        /// </summary>
        public void SendEmail()
        {
            Console.Write($"Sending email to {to}...");

            SmtpClient mailClient = new SmtpClient
            {
                Host = Host_, 
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from.Address, pw),
                Timeout = 20000,
            };

            using (var message = new MailMessage(from, to)
            {
                Subject = Subject_,
                Body = Body_,
                IsBodyHtml = true
            })
            {
                mailClient.Send(message);
            }

            Console.WriteLine("done.");
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
