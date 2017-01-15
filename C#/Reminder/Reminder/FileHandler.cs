using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System;
using System.Text;

namespace Reminder
{
    static class FileHandler
    {   
        /// <summary>
        /// Writes a string to the file that contains the reminders
        /// </summary>
        /// <param name="contents">String to be written</param>
        public static void WriteFile(string contents)
        {
            File.AppendAllText(ConfigurationManager.AppSettings["ReminderFileLocation"], contents);
        }

        /// <summary>
        /// Reads in the reminder file specified in App.config
        /// </summary>
        /// <returns>String array filled with the reminders</returns>
        public static string[] ReadFile()
        {
            return File.ReadAllLines(ConfigurationManager.AppSettings["ReminderFileLocation"]);
        }

        /// <summary>
        /// Reads in a specific file
        /// </summary>
        /// <param name="path">File to be read</param>
        /// <returns>String array filled with contents from given file</returns>
        public static string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }


        //TODO: Specify update renewal period, such as Month or Year or Day
        /// <summary>
        /// Updates a reminders date
        /// </summary>
        /// <param name="liMonthlyReminders">List containing reminders that need to be updated</param>
        /// <param name="sReminders">Array of all of the reminders in the file</param>
        public static void UpdateRenewalDate(List<string> liMonthlyReminders, string[] sReminders)
        {
            for (int i = 0; i < sReminders.Length; i++)
            {
                for (int j = 0; j < liMonthlyReminders.Count; j++)
                {
                    if (liMonthlyReminders[j] == sReminders[i]) // updates the reminders date
                    {
                        DateTime dtNextMonth = Convert.ToDateTime(Utilities.GetDateFromReminder(sReminders[i])).AddMonths(1);
                        sReminders[i] = dtNextMonth.ToString(Utilities.DATE_FORMAT) + "-" + Utilities.GetReminderTitleFromReminder(sReminders[i]);
                    }
                }
            }

            File.Delete(ConfigurationManager.AppSettings["ReminderFileLocation"]);
            WriteFile(string.Join(Environment.NewLine,sReminders));
        }
    }
}
