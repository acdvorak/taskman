using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
namespace TaskMan.Win32
{
    public static class API
    {
        /// <summary>
        ///     Retrieves information about the specified window.
        /// </summary>
        /// <param name="hwnd">
        ///     A handle to the window whose information is to be retrieved.
        /// </param>
        /// <param name="pwi">
        ///     A pointer to a <see cref="WINDOWINFO"/> structure to receive the information.
        ///     Note that you must set the <see cref="WINDOWINFO.cbSize"/> member to <c>sizeof(WINDOWINFO)</c>
        ///     <strong><em>before</em></strong> calling this function.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is zero.
        ///     To get extended error information, call <c>GetLastError</c>.
        /// </returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

        /// <summary>
        ///     Sets the specified window's show state.
        /// </summary>
        /// <param name="hWnd">
        ///     A handle to the window.
        /// </param>
        /// <param name="nCmdShow">
        ///     Controls how the window is to be shown. This parameter is ignored the first time an application calls
        ///     <c>ShowWindow</c>, if the program that launched the application provides a <c>STARTUPINFO</c> structure.
        ///     Otherwise, the first time <c>ShowWindow</c> is called, the value should be the value obtained by the <c>WinMain</c>
        ///     function in its <paramref name="nCmdShow"/> parameter. In subsequent calls, this parameter can be one of
        ///     the <see cref="ShowWindowCommand"/> values.
        /// </param>
        /// <returns>
        ///     If the operation was successfully started, the return value is nonzero.
        /// </returns>
        /// <remarks>
        ///     This function posts a show-window event to the message queue of the given window.
        ///     An application can use this function to avoid becoming nonresponsive while waiting for a nonresponsive
        ///     application to finish processing a show-window event.
        /// </remarks>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, [MarshalAs(UnmanagedType.I4)] ShowWindowCommand nCmdShow);

        /// <summary>
        ///     Sets the show state of a window without waiting for the operation to complete.
        /// </summary>
        /// <param name="hWnd">
        ///     A handle to the window.
        /// </param>
        /// <param name="nCmdShow">
        ///     Controls how the window is to be shown. For a list of possible values, see the description of the <see cref="ShowWindow"/> function.
        /// </param>
        /// <returns>
        ///     If the operation was successfully started, the return value is nonzero.
        /// </returns>
        /// <remarks>
        ///     This function posts a show-window event to the message queue of the given window.
        ///     An application can use this function to avoid becoming nonresponsive while waiting for a nonresponsive
        ///     application to finish processing a show-window event.
        /// </remarks>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, [MarshalAs(UnmanagedType.I4)] ShowWindowCommand nCmdShow);
    }
}
