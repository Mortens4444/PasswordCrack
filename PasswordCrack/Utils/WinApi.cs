using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PasswordCrack.Utils
{
    public static class WinApi
    {
        public const uint WM_CLOSE = 0x0010;

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    }
}
