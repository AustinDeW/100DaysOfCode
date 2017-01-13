using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Configuration;

//TODO: Add comments to make easier to understand
namespace Reminder
{
    public partial class Form1 : Form
    {
        EmailHandler em = null;
        string path = @ConfigurationManager.AppSettings["ReminderFileLocation"];
        int exitTime = 5;
        public Form1()
        {
            InitializeComponent();
            tbReminderName.KeyDown += (sender, e) => KeyDown_SubmitReminder(sender, e);

            try { em = new EmailHandler(); }
            catch (Exception ex) { Console.WriteLine("\n\n" + ex.Message + "\n\n" + ex.StackTrace); }

            timerExit.Start();
            CheckForReminder();
        }

        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            string reminderName = tbReminderName.Text;
            string renewalDate = dtpRenewalDate.Text;

            string strReminder = renewalDate + "-" + reminderName + Environment.NewLine;
            Console.WriteLine($"Reminder added : {strReminder}\n\n");
            FileHandler.WriteFile(path, strReminder);
        }

        private void CheckForReminder()
        {
            try
            {
                if (File.Exists(path))
                {
                    List<string> liMonthlyReminder = new List<string>();
                    string[] sReminders = FileHandler.ReadFile(path);
                    string sReminder = "";
                    string sDate = "";
                    bool bSendEmail = false;
                    for (int i = 0; i < sReminders.Length; ++i)
                    {
                        string date = sReminders[i].Substring(0, sReminders[i].IndexOf('-'));

                        DateTime dt = Convert.ToDateTime(date);

                        string format = "MM/dd/yyyy";

                        if (dt.ToString(format) == DateTime.Today.ToString(format) 
                                ||  dt.ToString(format) == DateTime.Today.AddDays(3).ToString(format))
                        {
                            sReminder += sReminders[i].Substring(sReminders[i].IndexOf('-') + 1) + " | ";

                            if(sReminders[i].EndsWith("*"))
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

        private void cbStopExit_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Stopped Exiting.\n\n");
            timerExit.Stop();
        }

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
