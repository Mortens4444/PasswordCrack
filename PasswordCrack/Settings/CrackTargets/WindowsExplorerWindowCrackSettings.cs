namespace PasswordCrack.Settings.CrackTargets
{
    /// <summary>
    /// You need to open the password dialog!
    /// </summary>
    public class WindowsExplorerWindowCrackSettings : WindowCrackSettings
    {
        public WindowsExplorerWindowCrackSettings()
        {
            WindowTitle = "Password needed";
            ErrorWindowTitle = "Compressed (zipped) Folders Error";
            UseSendKeysToCloseErrorWindow = false;
            HasErrorMessage = false;
            WaitForWindowInMs = 400;
            ExactErrorWindowTitleMatch = true;
        }
    }
}
