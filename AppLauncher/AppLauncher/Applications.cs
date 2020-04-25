using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AppLauncher
{
    public static class Applications
    {
        private const string Slack = "C:\\Users\\Michael.Templeton\\AppData\\Local\\slack\\slack.exe";
        private const string Outlook = "C:\\Program Files\\Microsoft Office\\Office16\\OUTLOOK.EXE";

        public static List<string> AppList = new List<string>()
        {
            Slack,
            Outlook
        };
    }
}
