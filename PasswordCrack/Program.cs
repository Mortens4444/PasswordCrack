using PasswordCrack.Utils;
using System;
using System.Linq;

namespace PasswordCrack
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var helpKeyWords = new[] { "h", "help", "sos", "101" };
            if (args.Any(arg => helpKeyWords.Contains(arg.TrimStart(new[] { '\\', '-' }), StringComparer.OrdinalIgnoreCase)))
            {
                HelpProvider.ShowHelp();
            }

            var crackSettings = CrackSettingBuilder.GetFromCommandLineArgs(args);
            AttackExecutor.Attack(crackSettings);
        }
    }
}
