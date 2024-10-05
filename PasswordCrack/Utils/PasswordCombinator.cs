using System;
using System.Collections.Generic;

namespace PasswordCrack.Utils
{
    public static class PasswordCombinator
    {
        public static HashSet<string> GetCasePermutations(string basePassword)
        {
            var result = new HashSet<string>(StringComparer.Ordinal);
            int n = basePassword.Length;

            for (int i = 0; i < (1 << n); i++)
            {
                var permutation = basePassword.ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    if (Char.IsLetter(permutation[j]))
                    {
                        permutation[j] = (i & (1 << j)) != 0 ? 
                            Char.ToUpper(permutation[j]) :
                            Char.ToLower(permutation[j]);
                    }
                }

                result.Add(new string(permutation));
            }

            return result;
        }
    }
}
