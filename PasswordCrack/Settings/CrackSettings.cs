using PasswordCrack.Enums;

namespace PasswordCrack.Settings
{
    public class CrackSettings
    {
        public CrackMode CrackMode { get; set; }

        public string FileToCrack { get; set; }

        public bool OpenFileToCrack { get; set; } = false;

        public bool UseCasePermutations { get; set; } = false;

        public DictionarySettings DictionarySettings { get; set; } = null;

        public BruteForceSettings BruteForceSettings { get; set; } = null;

        public WindowCrackSettings WindowCrackSettings { get; set; } = null;
    }
}
