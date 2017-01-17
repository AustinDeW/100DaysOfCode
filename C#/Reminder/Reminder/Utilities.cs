using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    //TODO: Add comments to Utiltites.cs
    static class Utilities
    {
        public static readonly string DATE_FORMAT = "MM/dd/yyyy";

        public static string GetDateFromReminder(string sReminder)
        {
            if(sReminder.Count(i => i == '-') == 2)
                return sReminder.Substring(sReminder.IndexOf('-') + 1, sReminder.LastIndexOf('-') - (sReminder.IndexOf('-') + 1));
            else
                return sReminder.Substring(0, sReminder.LastIndexOf('-'));
        }

        public static string GetReminderTitleFromReminder(string sReminder)
        {
            return sReminder.Substring(sReminder.LastIndexOf('-') + 1);
        }

        public static Reminder[] StringArrToReminderArr(string[] sReminders)
        {
            Reminder[] rReminders = new Reminder[sReminders.Length];
            for(int i = 0; i < sReminders.Length; i++)
            {
                if (sReminders[i].StartsWith("("))
                {
                    string[] sRenewalPeriod = sReminders[i].Substring(0, sReminders[i].IndexOf(')') + 1).Replace("(", "").Replace(")", "").Split(',');
                    rReminders[i].ReminderPeriod = Array.ConvertAll(sRenewalPeriod, int.Parse);
                }
                else rReminders[i].ReminderPeriod = new int[2] { 1, 3 };

                rReminders[i].Date = GetDateFromReminder(sReminders[i]);
                rReminders[i].Description = GetReminderTitleFromReminder(sReminders[i]);
            }

            return rReminders;
        }

        public static string ReminderArrToString(Reminder[] rReminders)
        {
            StringBuilder sbReminder = new StringBuilder();

            for(int i = 0; i < rReminders.Length; i++)
            {
                int iReminderPeriodLength = rReminders[i].ReminderPeriod.Length;
                sbReminder.Append("(");
                for(int j = 0; j < iReminderPeriodLength; j++)
                {
                    sbReminder.Append(rReminders[i].ReminderPeriod[j]);
                    
                    if(j != iReminderPeriodLength - 1)
                    {
                        sbReminder.Append(",");
                    }
                }
                sbReminder.Append(")-");
                sbReminder.Append(rReminders[i].Date);
                sbReminder.Append("-");
                sbReminder.Append(rReminders[i].Description);
                sbReminder.Append(Environment.NewLine);
            }

            return sbReminder.ToString();
        }
    }
}
