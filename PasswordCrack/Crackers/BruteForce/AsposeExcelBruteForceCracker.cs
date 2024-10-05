using Aspose.Cells;
using PasswordCrack.Settings;
using PasswordCrack.Utils;
using System;

namespace PasswordCrack.Crackers.BruteForce
{
    public class AsposeExcelBruteForceCracker : BruteForceCracker
    {
        public override bool TryOnePassword(CrackSettings crackSettings, string password, int numberOfTries)
        {
            Console.WriteLine("{0} Trying password: {1}", numberOfTries, password);

            try
            {
                var workbook = new Workbook(crackSettings.FileToCrack, new LoadOptions { Password = password });
                MessageSender.ShowInfo($"Password found: {password}");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
