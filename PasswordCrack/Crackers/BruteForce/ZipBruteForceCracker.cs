using Ionic.Zip;
using PasswordCrack.Settings;
using PasswordCrack.Utils;
using System;
using System.IO;

namespace PasswordCrack.Crackers.BruteForce
{
    public class ZipBruteForceCracker : BruteForceCracker
    {
        public override bool TryOnePassword(CrackSettings crackSettings, string password, int numberOfTries)
        {
            Console.WriteLine("{0} Trying password: {1}", numberOfTries, password);

            try
            {
                using (var zip = ZipFile.Read(crackSettings.FileToCrack))
                {
                    zip.Password = password;
                    zip.ExtractAll(Path.GetDirectoryName(crackSettings.FileToCrack));
                }
                MessageSender.ShowInfo($"Password found: {password}");
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("already exists"))
                {
                    MessageSender.ShowInfo(ex.Message);
                    return true;
                }
                return false;
            }
        }
    }
}
