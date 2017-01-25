using System;
using System.Configuration;
using Twilio;

namespace Reminder
{
    class TextMessageHandler
    {
        private const string TWILIO_NUMBER = "3858316451";
        private string toPhoneNumber = ConfigurationManager.AppSettings["ToPhoneNumber"];
        private TwilioRestClient twrClient = null;
        
        public TextMessageHandler()
        {
            string[] TwilioClientCredentials = FileHandler.ReadFile(ConfigurationManager.AppSettings["ReminderDataFileLocation"] + "TwilioData.txt");
            twrClient = new TwilioRestClient(TwilioClientCredentials[0], TwilioClientCredentials[1]);
        }

        public void SendTextMessage(string message)
        {
            Console.Write($"\nSending text to {toPhoneNumber}...");
            twrClient.SendMessage(TWILIO_NUMBER, toPhoneNumber, message);
            Console.WriteLine("done.");
        }

        public void SendTextMessage(string to, string message)
        {
            Console.Write($"\nSending text to {to}...");
            twrClient.SendMessage(TWILIO_NUMBER, to, message);
            Console.WriteLine("done.");
        }
    }
}
