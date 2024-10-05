using PasswordCrack.Settings;
using PasswordCrack.Utils;
using System;
using System.IO;
using System.Text;

namespace PasswordCrack.Crackers
{
    public abstract class DictionaryCracker
    {
        public abstract bool Attack(CrackSettings crackSettings);
    }

    public abstract class DictionaryCracker<TBruteForceCrackerType> : DictionaryCracker
        where TBruteForceCrackerType : BruteForceCracker, new()
    {
        private readonly TBruteForceCrackerType bruteForceCracker = new TBruteForceCrackerType();

        public override bool Attack(CrackSettings crackSettings)
        {
            Console.WriteLine("Starting dictionary attack...");

            int numberOfTries = 0;
            var passwords = crackSettings.DictionarySettings?.FileName != null ?
                File.ReadAllLines(crackSettings.DictionarySettings.FileName, crackSettings.DictionarySettings.Encoding) :
                ResourceHelper.ReadEmbeddedResource("PasswordCrack.password_list.txt", Encoding.UTF8).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int i = crackSettings.DictionarySettings == null ? 0 : crackSettings.DictionarySettings.SkipLines;
            while (i < passwords.Length)
            {
                var password = passwords[i];
                if (Cracker.TryPassword(crackSettings, password, ++numberOfTries, TryOnePassword))
                {
                    return true;
                }
                i++;
            }

            return false;
        }

        protected bool TryOnePassword(CrackSettings crackSettings, string password, int numberOfTries)
        {
            return bruteForceCracker.TryOnePassword(crackSettings, password, numberOfTries);
        }
    }
}
