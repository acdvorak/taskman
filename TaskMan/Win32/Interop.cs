using System;
using System.Diagnostics;

namespace TaskMan.Win32
{
    public static class Interop
    {
        /// <summary>
        ///     Minimizes the main window of the specified <paramref name="process"/>.
        /// </summary>
        /// <param name="process">
        ///     A process that may or may not have been started by the current process and that may or may not have
        ///     a main window associated with it.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the given <paramref name="process"/> has a main window and was successfully minimized;
        ///     otherwise <c>false</c>.
        /// </returns>
        public static bool Minimize(Process process)
        {
            return Minimize(process.MainWindowHandle);
        }

        /// <summary>
        ///     Minimizes the specified window.
        /// </summary>
        /// <param name="hWnd">
        ///     A pointer to the window to minimize.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified window was successfully minimized; otherwise <c>false</c>.
        /// </returns>
        public static bool Minimize(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero)
                return false;

            if (API.ShowWindowAsync(hWnd, ShowWindowCommand.SW_SHOWMINIMIZED))
                return true;

            return false;
        }
    }
}
