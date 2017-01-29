using System;
using System.Linq;
using System.Text;

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
        /// Gets the Reminder Period that the user wants to reminded
        /// </summary>
        /// <param name="sReminder">Reminder string to parse reminder period from</param>
        /// <returns>Reminder's Reminder Period(s)</returns>
        public static string[] GetReminderPeriod(string sReminder)
        {
            return sReminder.Substring(sReminder.IndexOf('('), sReminder.IndexOf(')') - sReminder.IndexOf('('))
                   .Replace("(", "")
                   .Replace(")", "")
                   .Split(',');
        }

        /// <summary>
        /// Gets the Contact Preference from a reminder
        /// </summary>
        /// <param name="sReminder">Reminder string to parse contact preference from</param>
        /// <returns>Reminder's contact preference ie. Text/Email/Both</returns>
        public static string GetContactPreference(string sReminder)
        {
            return sReminder.Substring(sReminder.IndexOf('{'), sReminder.IndexOf('}') + 1);
        }

        /// <summary>
        /// Creates Reminder objects from an array of strings
        /// </summary>
        /// <param name="sReminders">Array of string reminders</param>
        /// <returns>Array of Reminder objects</returns>
        public static Reminder[] StringArrToReminderArr(string[] sReminders)
        {
            Reminder[] rReminders = new Reminder[sReminders.Length];
            for (int i = 0; i < sReminders.Length; i++)
            {
                // Checks for contact preference, ie. Email/Text/Both
                rReminders[i].ContactPreference = sReminders[i].Contains("{") ? GetContactPreference(sReminders[i]) : "Email";

                // Checks for custom reminder period
                rReminders[i].ReminderPeriods = sReminders[i].Contains("(") ? Array.ConvertAll(GetReminderPeriod(sReminders[i]), int.Parse) : new int[2] { 1, 3 }; ;

                rReminders[i].ReminderUpdatePeriod = GetRenewalUpdatePeriodFromReminder(sReminders[i]);
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

            for (int i = 0; i < rReminders.Length; i++)
            {
                sbReminder.Append(rReminders[i].ContactPreference);
                sbReminder.Append("(");
                int inReminderPeriodLength = rReminders[i].ReminderPeriods.Length;
                for (int j = 0; j < inReminderPeriodLength; j++)
                {
                    sbReminder.Append(rReminders[i].ReminderPeriods[j]);

                    // Keeps appending ',' until it reaches last iteration
                    if (j != inReminderPeriodLength - 1)
                    {
                        sbReminder.Append(",");
                    }
                }
                sbReminder.Append(")-");
                sbReminder.Append(rReminders[i].Date);
                sbReminder.Append("-");
                sbReminder.Append(rReminders[i].Description);
                sbReminder.Append(rReminders[i].ReminderUpdatePeriod);
                sbReminder.Append(Environment.NewLine);
            }

            return sbReminder.ToString();
        }

        /// <summary>
        /// Appends a reminder toa string builder
        /// </summary>
        /// <param name="rReminder">Reminder to append</param>
        /// <returns>Reminder string</returns>
        public static string AppendReminder(Reminder rReminder)
        {
            return Environment.NewLine + rReminder.Description + " on " + rReminder.Date;
        }

        /// <summary>
        /// Allows you to add HTML to an email
        /// </summary>
        /// <param name="rReminder">Reminder to append</param>
        /// <returns>Reminder string</returns>
        public static string AppendReminderHTML(Reminder rReminder)
        {
            return Environment.NewLine +
                   rReminder.Description +
                   " on <span style=\"color: red; font-weight: bold\">" +
                   rReminder.Date +
                   "</span>";
        }

        /// <summary>
        /// Verifies that the Reminder Description field isn't empty
        /// </summary>
        /// <param name="description">Reminder Description to check</param>
        /// <param name="reminderDescription">If it passes, it gets outputted here</param>
        /// <returns>Whether or not it is valid</returns>
        public static bool VerifyReminderDescription(string description, out string reminderDescription)
        {
            if (description.Length > 0)
            {
                reminderDescription = description;
                return true;
            }
            else
            {
                reminderDescription = "";
                return false;
            }
        }

        /// <summary>
        /// Verifies that the Reminder Date is later than today's date
        /// </summary>
        /// <param name="date">Date selected</param>
        /// <param name="reminderDate">If it passes, it get outputted here</param>
        /// <returns>Whether or not it is valid</returns>
        public static bool VerifyReminderDate(string date, out string reminderDate)
        {
            if (Convert.ToDateTime(date) > DateTime.Now)
            {
                reminderDate = date;
                return true;
            }
            else
            {
                reminderDate = null;
                return false;
            }
        }

        /// <summary>
        /// Verifies that the reminder periods are all Integers
        /// </summary>
        /// <param name="periods">String array of reminder periods</param>
        /// <param name="reminderPeriods">If it passes, it is outputted here</param>
        /// <returns>Whether or not it is valid</returns>
        public static bool VerifyReminderPeriods(string[] periods, out int[] reminderPeriods)
        {
            try
            {
                reminderPeriods = Array.ConvertAll(periods, int.Parse);
                return true;
            }
            catch (Exception)
            {
                reminderPeriods = new int[0];
                return false;
            }

        }

        /// <summary>
        /// Verifies that it contains month/day/year/"" 
        /// </summary>
        /// <param name="updatePeriod">Update period</param>
        /// <param name="reminderUpdatePeriod">If it passes, it is outputted here</param>
        /// <returns>Whether or not it is valid</returns>
        public static bool VerifyReminderUpdatePeriod(string updatePeriod, out string reminderUpdatePeriod)
        {
            if (updatePeriod.Contains("month") || updatePeriod.Contains("day") || updatePeriod.Contains("year") || updatePeriod == "")
            {
                reminderUpdatePeriod = "[" + updatePeriod + "]";
                return true;
            }
            else
            {
                reminderUpdatePeriod = "";
                return false;
            }

        }

        /// <summary>
        /// Verifies that at least one of the checkboxes is checked
        /// </summary>
        /// <param name="cbTexting">Texing Checkbox value</param>
        /// <param name="cbEmail">Email Checkbox value</param>
        /// <param name="reminderContactPreferences">if it passes, it is outputted here</param>
        /// <returns>Whether or not it is valid</returns>
        public static bool VerifyContactPreferences(bool cbTexting, bool cbEmail, out string reminderContactPreferences)
        {
            if (cbTexting && cbEmail)
            {
                reminderContactPreferences = "{Both}";
                return true;
            }
            else if (cbTexting)
            {
                reminderContactPreferences = "{Text}";
                return true;
            }
            else if (cbEmail)
            {
                reminderContactPreferences = "{Email}";
                return true;
            }
            else
            {
                reminderContactPreferences = "";
                return false;
            }
        }    
    }
}
