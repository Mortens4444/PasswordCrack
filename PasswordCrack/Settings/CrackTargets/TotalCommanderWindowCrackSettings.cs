namespace PasswordCrack.Settings.CrackTargets
{
    /// <summary>
    /// You need to open the password dialog!
    /// </summary>
    public class TotalCommanderWindowCrackSettings : WindowCrackSettings
    {
        public TotalCommanderWindowCrackSettings()
        {
            WindowTitle = "Password required!";
            ErrorWindowTitle = "Password required!";
            UseSendKeysToCloseErrorWindow = false;
            HasErrorMessage = false;
            WaitForWindowInMs = 400;
            ExactErrorWindowTitleMatch = true;
        }
    }
}
