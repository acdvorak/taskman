using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Mono.Options;

namespace TaskMan
{
    internal static class Program
    {
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            var options = new OptionSet
                {
                    { "h|?|help", v => ShowHelp() }
                };

            args = options.Parse(args).ToArray();

            if (!args.Any())
                args = new[] { "taskmgr" };

            var processes = args.SelectMany(Process.GetProcessesByName).ToArray();

            if (processes.Any())
            {
                foreach (var process in processes)
                {
                    Minimize(process);
                }
            }
            else
            {
                foreach (var fileName in args)
                {
                    var process = Process.Start(new ProcessStartInfo { FileName = fileName });
                    while (!Minimize(process))
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    }
                }
            }
        }

        private static void ShowHelp()
        {
            var fullPath = Process.GetCurrentProcess().MainModule.FileVersionInfo.FileName;
            var fileName = Path.GetFileName(fullPath);
            var text = string.Format("{0}: Starts and immediately minimizes one or more programs.\n\n" +
                                     "Usage: {0} [ taskmgr [ notepad [ ... ] ] ]\n\n" +
                                     "If invoked with no arguments, starts and minimizes taskmgr by default.",
                                     fileName);
            var caption = string.Format("{0} help", fileName);
            MessageBox.Show(text, caption);
            Environment.Exit(0);
        }

        private static bool Minimize(Process process)
        {
            var hWnd = process.MainWindowHandle;
            return hWnd != IntPtr.Zero && ShowWindowAsync(hWnd, SW_SHOWMINIMIZED);
        }
    }
}