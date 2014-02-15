using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Mono.Options;

namespace TaskMan
{
    internal static class Program
    {
        private const int MaxTries = 5;
        private static int _numTries = 0;
        private static double _delayInSec = 3;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            var options = new OptionSet
                          {
                              { "d|delay", d => _delayInSec = double.Parse(d) },
                              { "h|?|help", v => ShowHelp() }
                          };

            args = options.Parse(args).ToArray();

            const string appName = "taskmgr";

            var processes = Process.GetProcessesByName(appName).ToArray();
            if (processes.Any())
            {
                processes.ForEach(Minimize);
            }
            else
            {
                Minimize(StartProcess(appName));
            }
        }

        private static Process StartProcess(string fileName)
        {
            return Process.Start(new ProcessStartInfo { FileName = fileName });
        }

        private static bool CanContinue()
        {
            if (_numTries++ > MaxTries)
                return false;
            Thread.Sleep(TimeSpan.FromSeconds(_delayInSec));
            return true;
        }

        private static void Minimize(Process process)
        {
            while (CanContinue() && !Win32.Interop.Minimize(process))
            {
            }
        }

        private static void ShowHelp()
        {
            var fullPath = Process.GetCurrentProcess().MainModule.FileVersionInfo.FileName;
            var fileName = Path.GetFileName(fullPath);
            var text = string.Format("{0}: Starts and immediately minimizes taskmgr.exe.\n\n" +
                                     "Usage: {0} [ --delay NUM_SECS ]\n\n",
                                     fileName);
            var caption = string.Format("{0} help", fileName);
            MessageBox.Show(text, caption);
            Environment.Exit(0);
        }
    }

    internal static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}