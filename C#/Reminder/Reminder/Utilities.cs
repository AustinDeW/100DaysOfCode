using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    static class Utilities
    {
        public static readonly string DATE_FORMAT = "MM/dd/yyyy";

        public static string GetDateFromReminder(string sReminder)
        {
            return sReminder.Substring(0, sReminder.IndexOf('-'));
        }

        public static string GetReminderTitleFromReminder(string sReminder)
        {
            return sReminder.Substring(sReminder.IndexOf('-') + 1);
        }
    }
}
