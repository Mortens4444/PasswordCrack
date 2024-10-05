using PasswordCrack.Settings;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PasswordCrack.Utils
{
    internal class WindowFinder
    {
        private static IntPtr foundWindowHandle = IntPtr.Zero;

        public static IntPtr GetWindowWithTitle(WindowCrackSettings windowCrackSettings)
        {
            if (windowCrackSettings.ExactErrorWindowTitleMatch)
            {
                return WinApi.FindWindow(null, windowCrackSettings.ErrorWindowTitle);
            }

            WinApi.EnumWindows(WindowEnumCallback, Marshal.StringToHGlobalUni(windowCrackSettings.ErrorWindowTitle));
            return foundWindowHandle;
        }

        private static bool WindowEnumCallback(IntPtr hWnd, IntPtr lParam)
        {
            var sb = new StringBuilder(256);
            if (WinApi.GetWindowText(hWnd, sb, sb.Capacity) > 0)
            {
                string windowTitle = sb.ToString();
                if (windowTitle.Contains(Marshal.PtrToStringUni(lParam)))
                {
                    foundWindowHandle = hWnd;
                    return false; // Stop enumeration
                }
            }
            return true; // Continue enumeration
        }
    }
}
