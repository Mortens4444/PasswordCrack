using PasswordCrack.Settings;
using PasswordCrack.Utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PasswordCrack.Crackers.BruteForce
{
    public class WindowBruteForceCracker : BruteForceCracker
    {
        public override bool TryOnePassword(CrackSettings crackSettings, string password, int numberOfTries)
        {
            var windowCrackSettings = crackSettings.WindowCrackSettings;
            Console.WriteLine("{0} Trying password: {1}", numberOfTries, password);
            Thread.Sleep(windowCrackSettings.WaitForWindowInMs);
            var hWnd = WinApi.FindWindow(null, windowCrackSettings.WindowTitle);
            if (hWnd != IntPtr.Zero)
            {
                WinApi.SetForegroundWindow(hWnd);
                SendKeys.SendWait(String.Concat(password, "\r"));

                if (windowCrackSettings.HasErrorMessage)
                {
                    Thread.Sleep(windowCrackSettings.WaitForWindowInMs);
                    var errorWindowHWnd = WindowFinder.GetWindowWithTitle(windowCrackSettings);
                    if (errorWindowHWnd != IntPtr.Zero)
                    {
                        WindowCloser.CloseErrorMessage(errorWindowHWnd, windowCrackSettings.UseSendKeysToCloseErrorWindow);
                    }
                    else
                    {
                        MessageSender.ShowInfo($"Password found: {password}");
                        return true;
                    }
                }
            }
            else
            {
                MessageSender.ShowError($"Cannot find password window with text: {windowCrackSettings.WindowTitle}{Environment.NewLine}Last tried password ({numberOfTries}.): {password}");
                return true;
            }
            return false;
        }
    }
}
