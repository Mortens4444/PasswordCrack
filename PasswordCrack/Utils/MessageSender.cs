using System.Windows.Forms;

namespace PasswordCrack.Utils
{
    public static class MessageSender
    {
        public static void ShowInfo(string text)
        {
            MessageBox.Show(text, "Success, or WaitForWindowInMs is too low", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}
