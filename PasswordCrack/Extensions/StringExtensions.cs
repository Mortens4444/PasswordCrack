using System;
using System.Text.RegularExpressions;

namespace PasswordCrack.Extensions
{
    public static class StringExtensions
    {
        private const int NotFound = -1;

        public static string GetNextValidPassword(this string currentPassword, char[] chars, Regex regex)
        {
            string nextPassword;

            do
            {
                nextPassword = currentPassword.GetNext(chars);
                currentPassword = nextPassword;
            } while (!regex.IsMatch(nextPassword));

            return nextPassword;
        }

        public static string GetNext(this string basicPassword, char[] chars)
        {
            if (basicPassword == null)
            {
                return String.Empty;
            }

            Span<char> password = stackalloc char[basicPassword.Length]; // Use Span for efficient in-place edits
            basicPassword.AsSpan().CopyTo(password); // Copy the existing password to Span

            int lastCharacterIndex = basicPassword.Length - 1;
            char firstChar = chars[0];
            char lastChar = chars[chars.Length - 1];

            // Handle incrementing the last character and carrying over if necessary
            while (lastCharacterIndex >= 0)
            {
                int charIndex = Array.IndexOf(chars, password[lastCharacterIndex]);

                if (charIndex == NotFound || password[lastCharacterIndex] == lastChar)
                {
                    password[lastCharacterIndex] = firstChar;
                    lastCharacterIndex--;
                }
                else
                {
                    password[lastCharacterIndex] = chars[charIndex + 1];
                    return password.ToString();
                }
            }

            // If all characters overflowed, append the firstChar to the start
            return firstChar + password.ToString();
        }
    }
}
