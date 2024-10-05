namespace PasswordCrack.Settings.CrackTargets
{
    public class AdobeWindowCrackSettings : WindowCrackSettings
    {
        public AdobeWindowCrackSettings()
        {
            WindowTitle = "Password";
            ErrorWindowTitle = "Adobe Acrobat";
            UseSendKeysToCloseErrorWindow = true;
            WaitForWindowInMs = 400;
            ExactErrorWindowTitleMatch = true;
        }
    }
}
