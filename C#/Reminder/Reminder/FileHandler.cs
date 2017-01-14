using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System;
using System.Text;

namespace Reminder
{
    //TODO: Add comments to FileHandler.cs
    static class FileHandler
    {   
        public static void WriteFile(string contents)
        {
            File.AppendAllText(ConfigurationManager.AppSettings["ReminderFileLocation"], contents);
        }

        public static string[] ReadFile()
        {
            return File.ReadAllLines(ConfigurationManager.AppSettings["ReminderFileLocation"]);
        }

        public static string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }


        //TODO: Specify update renewal period, such as Month or Year or Day
        public static void UpdateRenewalDate(List<string> liMonthlyReminders, string[] sReminders)
        {
            for (int i = 0; i < sReminders.Length; i++)
            {
                for (int j = 0; j < liMonthlyReminders.Count; j++)
                {
                    if (liMonthlyReminders[j] == sReminders[i])
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
