using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
namespace Reminder
{
    public partial class Form1 : Form
    {
        EmailHandler em = null;
        int exitTime = 5; // time that application will auto exit
        public Form1()
        {
            InitializeComponent();
            tbReminderName.KeyDown += (sender, e) => KeyDown_SubmitReminder(sender, e); // Allows 'enter' key to submit 

            try { em = new EmailHandler(); }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n" + ex.Message + "\n\n" + ex.StackTrace);
                EmailHandler.SendErrorEmail(ex);
            }


            CheckForReminder();
        }

        /// <summary>
        /// Adds a reminder to the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            string reminderName = tbReminderName.Text;
            string renewalDate = dtpRenewalDate.Text;

            string strReminder = renewalDate + "-" + reminderName + Environment.NewLine;
            Console.WriteLine($"Reminder added : {strReminder}\n\n");
            FileHandler.WriteFile(strReminder);
        }

        //TODO: Change the way email message is composed
        /// <summary>
        /// Checks the reminder file to see if there are any reminders within the time frame
        /// </summary>
        private void CheckForReminder()
        {
            try
            {
                if (File.Exists(ConfigurationManager.AppSettings["ReminderFileLocation"]))
                {
                    List<string> liMonthlyReminders = new List<string>(); // List that contains reminders that need to have date updated
                    Reminder[] rReminders = Utilities.StringArrToReminderArr(FileHandler.ReadFile());// All of the reminders from the reminder file
                    string sDate = "";
                    string sReminder = "";
                    for (int i = 0; i < rReminders.Length; ++i)
                    {
                        DateTime dtReminderDate = Convert.ToDateTime(rReminders[i].Date);
                        bool bRenewsToday = dtReminderDate.ToString(Utilities.DATE_FORMAT) == DateTime.Today.ToString(Utilities.DATE_FORMAT);

                        if (bRenewsToday || CheckIfReminderIsWithinDateRange(rReminders[i].ReminderPeriod, dtReminderDate))
                        { 
                            if (rReminders[i].Description.EndsWith("*") && bRenewsToday) // '*' signifies a reminder that needs to be auto updated
                            {
                                liMonthlyReminders.Add(rReminders[i].Description);
                            }

                            // Concatenates so that I can store all reminders and dates in one string
                            // so all reminders can be sent in one email
                            sReminder += rReminders[i].Description + " | ";
                            sDate += rReminders[i].Date + " | ";
                        }

                    }

                    // If sReminder has text in it, then email should be sent
                    if (sReminder != "")
                    {
                        em.Subject_ = "Reminder: " + sReminder;
                        em.Body_ = $"Just a reminder that your {sReminder} on {sDate}!";
                        em.SendEmail();

                        if (liMonthlyReminders != null)
                        {
                            FileHandler.UpdateRenewalDate(liMonthlyReminders, rReminders);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                EmailHandler.SendErrorEmail(ex);
            }

            timerExit.Start(); // Start auto-exit countdown timer
        }

        /// <summary>
        /// Checks to see if today's date is x days from the reminder's date 
        /// </summary>
        /// <param name="iReminderPeriod">Array of days to add to today's date</param>
        /// <param name="dtReminderDate">Date of a reminder</param>
        /// <returns>Whether or not today's date is within the specified range</returns>
        private bool CheckIfReminderIsWithinDateRange(int[] iReminderPeriod, DateTime dtReminderDate)
        {
            for(int i = 0; i < iReminderPeriod.Length; i++)
            {
                // Adds x amount of days to today's date to check if the reminder's date is within range
                if(DateTime.Today.AddDays(iReminderPeriod[i]) == dtReminderDate)
                {
                    return true;
                }
            }

            return false;
        }

        private void timerExit_Tick(object sender, EventArgs e)
        {
            exitTime--;
            Console.WriteLine("Exiting in " + exitTime + "...");
            if(exitTime < 0 && !cbStopExit.Checked)
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// If checkbox is checked it will stop application from auto exiting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStopExit_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Stopped Exiting.\n\n");
            timerExit.Stop();
        }


        /// <summary>
        /// KeyDown event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDown_SubmitReminder(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    btnAddReminder.PerformClick();
                    break;
                case Keys.F1:
                    cbStopExit.Checked = true;
                    break;
            }
        }
    }
}
