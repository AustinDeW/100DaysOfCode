using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Reminder
{
    public partial class Form1 : Form
    {
        int exitTime = 5; // time that application will auto exit
        public Form1()
        {
            InitializeComponent();

            // Handles key press events on form
            this.KeyPreview = true; 
            this.KeyPress += (sender, e) => KeyPress_EventHandler(sender, e);    
                   
            //work!!
            //CheckForReminder();
        }

        /// <summary>
        /// Adds a reminder to the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            Reminder[] rReminders = new Reminder[1];
            bool isValid = true;
            string sErrorMessage = "";

            if(!Utilities.VerifyReminderDescription(tbReminderDescription.Text, out rReminders[0].Description))
            {
                sErrorMessage += "\nError: Description length has to be at least 1 character long!\n\n";
                isValid = false;
            }
            if(!Utilities.VerifyReminderDate(dtpReminderDate.Text, out rReminders[0].Date))
            {
                sErrorMessage += "\nError: Date has to be later than today's date!\n\n";
                isValid = false;
            }
            if(!Utilities.VerifyReminderPeriods(tbReminderPeriods.Text.Split(','), out rReminders[0].ReminderPeriods))
            {
                sErrorMessage += "\nError: Reminder Periods have to be numeric!\nExample: 1,3,5 or 2,4 or 1\n\n";
                isValid = false;
            }
            if (!Utilities.VerifyReminderUpdatePeriod(tbReminderUpdatePeriod.Text.ToLower(), out rReminders[0].ReminderUpdatePeriod))
            {
                sErrorMessage += "\nError: Update Period should specify whether or not you want to update the reminder's date regularly!\n" +
                                 "Leave blank, if it is just a one time reminder!\n" +
                                 "Example: 1 month or 23 days or 2 years\n\n";
                isValid = false;
            }
            else rReminders[0].Description += "*";
            if(!Utilities.VerifyContactPreferences(cbTexting.Checked, cbEmail.Checked, out rReminders[0].ContactPreference))
            {
                sErrorMessage += "\nError: Please check at least one of the Contact Preferences checkboxes!\n\n";
                isValid = false;
            }

            if(isValid)
            {
                Console.WriteLine($"Reminder added : {rReminders[0].Description}\n\n");
                FileHandler.WriteFile(Utilities.ReminderArrToString(rReminders));
            }
            else
            {
                MessageBox.Show(sErrorMessage, "Errors");
            }
        }

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
                    StringBuilder sbEmailReminder = new StringBuilder();
                    StringBuilder sbTextReminder = new StringBuilder();

                    int intRemindersLength = rReminders.Length;
                    for (int i = 0; i < intRemindersLength; ++i)
                    {
                        DateTime dtReminderDate = Convert.ToDateTime(rReminders[i].Date);
                        bool bRenewsToday = dtReminderDate.ToString(Utilities.DATE_FORMAT) == DateTime.Today.ToString(Utilities.DATE_FORMAT);

                        if (bRenewsToday || CheckIfReminderIsWithinDateRange(rReminders[i].ReminderPeriods, dtReminderDate))
                        {
                            if (rReminders[i].Description.EndsWith("*") && bRenewsToday) // '*' signifies a reminder that needs to be auto updated
                            {
                                liMonthlyReminders.Add(rReminders[i].Description);
                            }

                            // Concatenates so that I can store all reminders and dates in one string
                            // so all reminders can be sent in one email or text                            
                            if(rReminders[i].ContactPreference.ToLower().Contains("text"))
                            {
                                sbTextReminder.Append(Utilities.AppendReminder(rReminders[i]));
                            }
                            else if(rReminders[i].ContactPreference.ToLower().Contains("both"))
                            {
                                sbTextReminder.Append(Utilities.AppendReminder(rReminders[i]));
                                sbEmailReminder.Append(Utilities.AppendReminderHTML(rReminders[i]));
                            }
                            else
                            {
                                sbEmailReminder.Append(Utilities.AppendReminderHTML(rReminders[i]));
                            }
                        }
                    }

                    if(sbEmailReminder.Length > 0 && sbTextReminder.Length > 0)
                    {
                        EmailHandler.SendEmail("Reminder: ", $"Just a reminder that your {sbEmailReminder.ToString()}!");
                        TextMessageHandler txtm = new TextMessageHandler();
                        txtm.SendTextMessage($"Reminder: Just a reminder that your {sbTextReminder.ToString()}!");
                    }
                    else if(sbTextReminder.Length > 0)
                    {
                        TextMessageHandler txtm = new TextMessageHandler();
                        txtm.SendTextMessage($"Reminder: Just a reminder that your {sbTextReminder.ToString()}!");
                    }
                    else if(sbEmailReminder.Length > 0)
                    {
                        EmailHandler.SendEmail("Reminder: ", $"Just a reminder that your {sbEmailReminder.ToString()}!");
                    }

                    // If sReminder has text in it, then email should be sent
                    if (liMonthlyReminders.Count > 0)
                    {
                        FileHandler.UpdateRenewalDate(liMonthlyReminders, rReminders);
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
        private void KeyPress_EventHandler(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case (char) Keys.Enter:
                    btnAddReminder.PerformClick();
                    break;
                case (char) 17: // ctrl + q
                    cbStopExit.Checked = true;
                    break;
            }
        }
    }
}
