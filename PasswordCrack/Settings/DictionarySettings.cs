using System.Text;

namespace PasswordCrack.Settings
{
    public class DictionarySettings
    {
        public string FileName { get; set; } = null;

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public int SkipLines { get; set; } = 0;
    }
}
