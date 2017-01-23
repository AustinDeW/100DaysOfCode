using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    static class Utilities
    {
        // Format that the reminder date needs to be in
        public static readonly string DATE_FORMAT = "MM/dd/yyyy";

        /// <summary>
        /// Gets the date from a reminder string
        /// </summary>
        /// <param name="sReminder">Reminder string to parse date from</param>
        /// <returns>Reminder's date</returns>
        public static string GetDateFromReminder(string sReminder)
        {
            try
            {
                // Checks whether user is specifying custom renewal period and returns corresponding date
                if (sReminder.Count(i => i == '-') == 2)
                    return sReminder.Substring(sReminder.IndexOf('-') + 1, sReminder.LastIndexOf('-') - (sReminder.IndexOf('-') + 1));
                else
                    return sReminder.Substring(0, sReminder.LastIndexOf('-'));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                EmailHandler.SendErrorEmail(ex);

                return "";                
            }
        }

        /// <summary>
        /// Gets the description from a reminder string
        /// </summary>
        /// <param name="sReminder">Reminder string to parse title from</param>
        /// <returns>Reminder's description</returns>
        public static string GetReminderDescriptionFromReminder(string sReminder)
        {
            return sReminder.Contains("[") ? 
                sReminder.Substring(sReminder.LastIndexOf('-') + 1, sReminder.LastIndexOf('[') - (sReminder.LastIndexOf('-') + 1)) :
                sReminder.Substring(sReminder.LastIndexOf('-') + 1);
        }
        
        /// <summary>
        /// Gets the Renewal Update Period from a reminder string
        /// </summary>
        /// <param name="sReminder">Reminder string to parse update period from</param>
        /// <returns>Reminder's Renewal Update Period</returns>
        public static string GetRenewalUpdatePeriodFromReminder(string sReminder)
        {   
            return sReminder.Contains("[") ? sReminder.Substring(sReminder.LastIndexOf('[')) : "";
        }

        /// <summary>
        /// Creates Reminder objects from an array of strings
        /// </summary>
        /// <param name="sReminders">Array of string reminders</param>
        /// <returns>Array of Reminder objects</returns>
        public static Reminder[] StringArrToReminderArr(string[] sReminders)
        {
            Reminder[] rReminders = new Reminder[sReminders.Length];
            for(int i = 0; i < sReminders.Length; i++)
            {
                // Checks for custom reminder period
                if (sReminders[i].StartsWith("("))
                {
                    string[] sRenewalPeriod = sReminders[i].Substring(0, sReminders[i].IndexOf(')') + 1).Replace("(", "").Replace(")", "").Split(',');
                    rReminders[i].ReminderPeriod = Array.ConvertAll(sRenewalPeriod, int.Parse);
                }
                else rReminders[i].ReminderPeriod = new int[2] { 1, 3 };

                rReminders[i].RenewalUpdatePeriod = GetRenewalUpdatePeriodFromReminder(sReminders[i]);
                rReminders[i].Date = GetDateFromReminder(sReminders[i]);
                rReminders[i].Description = GetReminderDescriptionFromReminder(sReminders[i]);
            }

            return rReminders;
        }

        /// <summary>
        /// Converts array of Reminders to a single string
        /// </summary>
        /// <param name="rReminders">Array of Reminder objects</param>
        /// <returns>All reminders concatenated into one string</returns>
        public static string ReminderArrToString(Reminder[] rReminders)
        {
            StringBuilder sbReminder = new StringBuilder();

            for(int i = 0; i < rReminders.Length; i++)
            {
                int inReminderPeriodLength = rReminders[i].ReminderPeriod.Length;
                sbReminder.Append("(");
                for(int j = 0; j < inReminderPeriodLength; j++)
                {
                    sbReminder.Append(rReminders[i].ReminderPeriod[j]);
                    
                    // Keeps appending ',' until it reaches last iteration
                    if(j != inReminderPeriodLength - 1)
                    {
                        sbReminder.Append(",");
                    }
                }
                sbReminder.Append(")-");
                sbReminder.Append(rReminders[i].Date);
                sbReminder.Append("-");
                sbReminder.Append(rReminders[i].Description);
                sbReminder.Append(rReminders[i].RenewalUpdatePeriod);
                sbReminder.Append(Environment.NewLine);
            }

            return sbReminder.ToString();
        }
    }
}
