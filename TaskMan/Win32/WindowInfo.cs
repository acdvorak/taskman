﻿using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
namespace TaskMan.Win32
{
    /// <summary>
    ///     Contains window information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWINFO
    {
        /// <summary>
        ///     The size of the structure, in bytes. The caller must set this member to <c>sizeof(WINDOWINFO)</c>.
        /// </summary>
        public uint cbSize;

        /// <summary>
        ///     The coordinates of the window.
        /// </summary>
        public RECT rcWindow;

        /// <summary>
        ///     The coordinates of the client area.
        /// </summary>
        public RECT rcClient;

        /// <summary>
        ///     The window styles. For a table of window styles, see <see cref="WindowStyles"/>.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public WindowStyles dwStyle;

        /// <summary>
        ///     The extended window styles. For a table of extended window styles, see <see cref="ExtendedWindowStyles"/>.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public ExtendedWindowStyles dwExStyle;

        /// <summary>
        ///     The window status. If this member is <c>WS_ACTIVECAPTION (0x0001)</c>, the window is active. Otherwise, this member is zero.
        /// </summary>
        public uint dwWindowStatus;

        /// <summary>
        ///     The width of the window border, in pixels.
        /// </summary>
        public uint cxWindowBorders;

        /// <summary>
        ///     The height of the window border, in pixels.
        /// </summary>
        public uint cyWindowBorders;

        /// <summary>
        ///     The window class atom (see RegisterClass).
        /// </summary>
        public ushort atomWindowType;

        /// <summary>
        ///     The Windows version of the application that created the window.
        /// </summary>
        public ushort wCreatorVersion;

        /// <summary>
        ///     Allows automatic initialization of <see cref="cbSize"/> with <c>new WINDOWINFO(null/true/false)</c>.
        /// </summary>
        /// <param name="dummy">
        ///     Dummy parameter.  Pass anything you want - the value is ignored.  This parameter is only present
        ///     to work around a C# language restriction that prevents <c>struct</c>s from having an explicit
        ///     parameterless constructor.
        /// </param>
        // ReSharper disable once UnusedParameter.Local
        public WINDOWINFO(bool? dummy)
            : this()
        {
            cbSize = (UInt32)(Marshal.SizeOf(typeof(WINDOWINFO)));
        }
    }
}
