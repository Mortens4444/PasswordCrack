using System;
using System.Windows.Forms;

namespace PasswordCrack.Utils
{
    public static class WindowCloser
    {
        public static void CloseErrorMessage(IntPtr hwnd, bool useSendKeys)
        {
            if (hwnd == IntPtr.Zero)
            {
                MessageSender.ShowError("Cannot find error window");
            }

            if (useSendKeys)
            {
                WinApi.SetForegroundWindow(hwnd);
                SendKeys.SendWait("\r");
            }
            else
            {
                WinApi.PostMessage(hwnd, WinApi.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }
}
