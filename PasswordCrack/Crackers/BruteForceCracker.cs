using PasswordCrack.Extensions;
using PasswordCrack.Settings;
using System;

namespace PasswordCrack.Crackers
{
    public abstract class BruteForceCracker
    {
        public bool Attack(CrackSettings crackSettings)
        {
            Console.WriteLine("Starting brute-force attack...");

            int numberOfTries = 0;
            var password = crackSettings.BruteForceSettings.StartPassword;

            while (true)
            {
                if (Cracker.TryPassword(crackSettings, password, ++numberOfTries, TryOnePassword))
                {
                    return true;
                }

                password = password.GetNextValidPassword(crackSettings.BruteForceSettings.Chars, crackSettings.BruteForceSettings.RegEx);
            }
        }

        public abstract bool TryOnePassword(CrackSettings crackSettings, string password, int numberOfTries);
    }
}
