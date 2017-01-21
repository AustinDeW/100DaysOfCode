using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System;

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
            try
            {
                File.AppendAllText(ConfigurationManager.AppSettings["ReminderFileLocation"], contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                EmailHandler.SendErrorEmail(ex);
            }
        }

        /// <summary>
        /// Reads in the reminder file specified in App.config
        /// </summary>
        /// <returns>String array filled with the reminders</returns>
        public static string[] ReadFile()
        {
            try
            {
                return File.ReadAllLines(ConfigurationManager.AppSettings["ReminderFileLocation"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                EmailHandler.SendErrorEmail(ex);

                return new string[0];
            }
        }

        /// <summary>
        /// Reads in a specific file
        /// </summary>
        /// <param name="path">File to be read</param>
        /// <returns>String array filled with contents from given file</returns>
        public static string[] ReadFile(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                EmailHandler.SendErrorEmail(ex);

                return new string[0];
            }
        }

        /// <summary>
        /// Updates a reminders date
        /// </summary>
        /// <param name="liMonthlyReminders">List containing reminders that need to be updated</param>
        /// <param name="sReminders">Array of all of the reminders in the file</param>
        public static void UpdateRenewalDate(List<string> liMonthlyReminders, Reminder[] rReminders)
        {
            try
            {
                Console.Write("\nStarted updating reminder file...");
                int rRemindersLength = rReminders.Length;
                for (int i = 0; i < rRemindersLength; i++)
                {
                    for (int j = 0; j < liMonthlyReminders.Count; j++)
                    {
                        if (liMonthlyReminders[j] == rReminders[i].Description) // updates the reminders date
                        {
                            DateTime newDate = new DateTime();
                            string renewalUpdatePeriod = rReminders[i].RenewalUpdatePeriod.ToLower().Trim();
                            if (renewalUpdatePeriod.Contains("m"))
                            {
                                int months = Convert.ToInt32(renewalUpdatePeriod.Substring(1, renewalUpdatePeriod.IndexOf('m') - 1));
                                newDate = Convert.ToDateTime(rReminders[i].Date).AddMonths(months);
                            }
                            else if(renewalUpdatePeriod.Contains("d"))
                            {
                                int days = Convert.ToInt32(renewalUpdatePeriod.Substring(1, renewalUpdatePeriod.IndexOf('d') - 1));
                                newDate = Convert.ToDateTime(rReminders[i].Date).AddDays(days);
                            }
                            else if(renewalUpdatePeriod.Contains("y"))
                            {
                                int years = Convert.ToInt32(renewalUpdatePeriod.Substring(1, renewalUpdatePeriod.IndexOf('y') - 1));
                                newDate = Convert.ToDateTime(rReminders[i].Date).AddYears(years);
                            }

                            rReminders[i].Date = newDate.ToString(Utilities.DATE_FORMAT);
                        }
                    }
                }

                File.Delete(ConfigurationManager.AppSettings["ReminderFileLocation"]);
                WriteFile(Utilities.ReminderArrToString(rReminders));
                Console.WriteLine("done.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                EmailHandler.SendErrorEmail(ex);
            }
        }
    }
}
