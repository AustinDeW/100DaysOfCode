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
        string path = @ConfigurationManager.AppSettings["ReminderFileLocation"]; // location of file that contains reminders
        int exitTime = 5; // time that application will auto exit
        public Form1()
        {
            InitializeComponent();
            tbReminderName.KeyDown += (sender, e) => KeyDown_SubmitReminder(sender, e); // Allows 'enter' key to submit 

            try { em = new EmailHandler(); }
            catch (Exception ex) { Console.WriteLine("\n\n" + ex.Message + "\n\n" + ex.StackTrace); }

            timerExit.Start(); // start auto exit countdown timer
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
            FileHandler.WriteFile(path, strReminder);
        }

        /// <summary>
        /// Checks the reminder file to see if there are any reminders within the time frame
        /// </summary>
        private void CheckForReminder()
        {
            try
            {
                if (File.Exists(path))
                {
                    List<string> liMonthlyReminder = new List<string>(); // List that contains reminders that need to have date updated
                    string[] sReminders = FileHandler.ReadFile(path); // All of the reminders from the reminder file
                    string sReminder = "";
                    string sDate = "";
                    bool bSendEmail = false;
                    for (int i = 0; i < sReminders.Length; ++i)
                    {
                        // Reminder date
                        string date = sReminders[i].Substring(0, sReminders[i].IndexOf('-'));

                        DateTime dt = Convert.ToDateTime(date);

                        string format = "MM/dd/yyyy";

                        //TODO: Allow user to specify time frame to send reminder
                        if (dt.ToString(format) == DateTime.Today.ToString(format) 
                                ||  dt.ToString(format) == DateTime.Today.AddDays(3).ToString(format)) // Checks if a reminder is within the time frame
                        {
                            sReminder += sReminders[i].Substring(sReminders[i].IndexOf('-') + 1) + " | ";

                            if(sReminders[i].EndsWith("*")) // '*' signifies a reminder that needs to be auto updated
                            {
                                liMonthlyReminder.Add(sReminders[i]);
                            }

                            sDate += date + " | ";
                            em.Subject_ = "Reminder: " + sReminder;
                            em.Body_ = $"Just a reminder that your {sReminder} on {sDate}!";
                            bSendEmail = true;
                        }
                    }

                    //allows to be sent all in one email.
                    if (bSendEmail)
                    {
                        em.SendEmail();

                        if (liMonthlyReminder != null)
                        {
                            FileHandler.UpdateRenewalDate(liMonthlyReminder);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
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
