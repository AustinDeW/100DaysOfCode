using System.Collections.Generic;
using System.IO;

namespace Reminder
{
    static class FileHandler
    {   
        public static void WriteFile(string path, string contents)
        {
            File.AppendAllText(path, contents);
        }

        public static string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }

        //TODO: Build function
        public static void UpdateRenewalDate(List<string> dates)
        {
            foreach (var s in dates)
            {
                System.Console.WriteLine(s);
            }
        }
    }
}
