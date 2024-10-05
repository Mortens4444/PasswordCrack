using PasswordCrack.Settings;
using PasswordCrack.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordCrack.Crackers
{
    public static class Cracker
    {
        public static bool TryPassword(CrackSettings crackSettings, string password, int numberOfTries, Func<CrackSettings, string, int, bool> passwordCheck)
        {
            var permutations = crackSettings.UseCasePermutations ?
                PasswordCombinator.GetCasePermutations(password).ToList() :
                new List<string> { password };

            foreach (var permutation in permutations)
            {
                if (passwordCheck(crackSettings, permutation, numberOfTries))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
