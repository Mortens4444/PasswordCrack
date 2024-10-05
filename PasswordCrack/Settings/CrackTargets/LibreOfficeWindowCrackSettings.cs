namespace PasswordCrack.Settings.CrackTargets
{
    public class LibreOfficeWindowCrackSettings : WindowCrackSettings
    {
        public LibreOfficeWindowCrackSettings()
        {
            WindowTitle = "Enter Password - Filename.docx - LibreOffice";
            ErrorWindowTitle = "Warning";
            UseSendKeysToCloseErrorWindow = false;
            WaitForWindowInMs = 400;
            ExactErrorWindowTitleMatch = true;
        }
    }
}
