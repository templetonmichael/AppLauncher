using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.IO;

namespace AppLauncher
{
    class Controller
    {
        static void Main(string[] args)
        {
            List<Process> processes = new List<Process>();
            try
            {
                foreach (var app in Applications.AppList)
                {
                    var process = new Process {StartInfo = {FileName = app}};
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
