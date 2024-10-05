namespace PasswordCrack.Settings
{
    public class WindowCrackSettings
    {
        public string WindowTitle { get; set; }

        public string ErrorWindowTitle { get; set; }

        public int WaitForWindowInMs { get; set; } = 300;

        public bool UseSendKeysToCloseErrorWindow { get; set; } = false;

        public bool ExactErrorWindowTitleMatch { get; set; } = true;

        public bool HasErrorMessage { get; set; } = true;
    }
}
