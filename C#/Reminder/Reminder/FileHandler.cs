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
    }
}
