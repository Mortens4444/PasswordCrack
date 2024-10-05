using PasswordCrack.Crackers;
using PasswordCrack.Crackers.BruteForce;
using PasswordCrack.Crackers.Dictionary;
using PasswordCrack.Enums;
using PasswordCrack.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace PasswordCrack.Utils
{
    public static class AttackExecutor
    {
        private static readonly Dictionary<CrackMode, Func<CrackSettings, DictionaryCracker>> dictionaryCrackers = new Dictionary<CrackMode, Func<CrackSettings, DictionaryCracker>>()
        {
            { CrackMode.Word, settings => new AsposeWordDictionaryCracker() },
            { CrackMode.Pdf, settings => new AsposePdfDictionaryCracker() },
            { CrackMode.Excel, settings => new AsposeExcelDictionaryCracker() },
            { CrackMode.Zip, settings => new ZipDictionaryCracker() },
            { CrackMode.Window, settings => new WindowDictionaryCracker() }
        };

        private static readonly Dictionary<CrackMode, Func<CrackSettings, BruteForceCracker>> bruteForceCrackers = new Dictionary<CrackMode, Func<CrackSettings, BruteForceCracker>>()
        {
            { CrackMode.Word, settings => new AsposeWordBruteForceCracker() },
            { CrackMode.Pdf, settings => new AsposePdfBruteForceCracker() },
            { CrackMode.Excel, settings => new AsposeExcelBruteForceCracker() },
            { CrackMode.Zip, settings => new ZipBruteForceCracker() },
            { CrackMode.Window, settings => new WindowBruteForceCracker() }
        };

        public static void Attack(CrackSettings crackSettings)
        {
            if (crackSettings.OpenFileToCrack)
            {
                Process.Start(crackSettings.FileToCrack);
                Thread.Sleep(5000);
            }

            var passwordFoundOrStopped = false;
            if (crackSettings.DictionarySettings != null)
            {
                passwordFoundOrStopped = ExecuteDictionaryAttack(crackSettings);
            }

            if (!passwordFoundOrStopped && crackSettings.BruteForceSettings != null)
            {
                ExecuteBruteForceAttack(crackSettings);
            }
        }

        public static bool ExecuteDictionaryAttack(CrackSettings crackSettings)
        {
            if (dictionaryCrackers.TryGetValue(crackSettings.CrackMode, out var createCracker))
            {
                var cracker = createCracker(crackSettings);
                return cracker.Attack(crackSettings);
            }
            throw new NotImplementedException();
        }

        public static void ExecuteBruteForceAttack(CrackSettings crackSettings)
        {
            if (bruteForceCrackers.TryGetValue(crackSettings.CrackMode, out var createCracker))
            {
                var cracker = createCracker(crackSettings);
                cracker.Attack(crackSettings);
            }
        }
    }
}
