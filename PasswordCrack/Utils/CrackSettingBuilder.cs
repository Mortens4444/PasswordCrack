using PasswordCrack.Enums;
using PasswordCrack.Settings;
using PasswordCrack.Settings.CrackTargets;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace PasswordCrack.Utils
{
    public static class CrackSettingBuilder
    {
        public static CrackSettings GetFromCommandLineArgs(string[] args)
        {
            try
            {
                var crackSettings = new CrackSettings();
                foreach (var arg in args)
                {
                    var argument = arg.TrimStart(new[] { '-', '\\' });
                    if (argument.StartsWith("word", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.CrackMode = CrackMode.Word;
                    }
                    else if (argument.StartsWith("pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.CrackMode = CrackMode.Pdf;
                    }
                    else if (argument.StartsWith("excel", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.CrackMode = CrackMode.Excel;
                    }
                    else if (argument.StartsWith("zip", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.CrackMode = CrackMode.Zip;
                    }
                    else if (argument.StartsWith("file", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.FileToCrack = argument.Substring(5).Trim('"');
                    }
                    else if (argument.StartsWith("adobeWindow", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.CrackMode = CrackMode.Window;
                        crackSettings.WindowCrackSettings = new AdobeWindowCrackSettings();
                    }
                    else if (argument.StartsWith("libreOfficeWindow", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.CrackMode = CrackMode.Window;
                        crackSettings.WindowCrackSettings = new LibreOfficeWindowCrackSettings();
                    }
                    else if (argument.StartsWith("totalCommanderWindow", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.CrackMode = CrackMode.Window;
                        crackSettings.WindowCrackSettings = new TotalCommanderWindowCrackSettings();
                    }
                    else if (argument.StartsWith("windowsExplorerWindow", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.CrackMode = CrackMode.Window;
                        crackSettings.WindowCrackSettings = new WindowsExplorerWindowCrackSettings();
                    }
                    else if (argument.Equals("casePermutations", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.UseCasePermutations = true;
                    }
                    else if (argument.Equals("openFileWhenStart", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.OpenFileToCrack = true;
                    }
                    else if (argument.Equals("bruteForce", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.BruteForceSettings = new BruteForceSettings();
                    }
                    else if (argument.Equals("dictionary", StringComparison.OrdinalIgnoreCase))
                    {
                        crackSettings.DictionarySettings = new DictionarySettings();
                    }
                }
                if (crackSettings.CrackMode == CrackMode.Window && crackSettings.WindowCrackSettings == null)
                {
                    crackSettings.WindowCrackSettings = new WindowCrackSettings();
                }

                // Second round for dictionary-specific settings
                foreach (var arg in args)
                {
                    var argument = arg.TrimStart(new[] { '-', '\\' });
                    if (argument.StartsWith("dictFile", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.BruteForceSettings == null)
                        {
                            ShowError("Please provide -dictionary parameter if you want to perform a dictionary attack, or remove dictFile param from command line.");
                        }
                        crackSettings.DictionarySettings.FileName = argument.Substring(9).Trim('"');
                    }
                    else if (argument.StartsWith("dictEncoding", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.BruteForceSettings == null)
                        {
                            ShowError("Please provide -dictionary parameter if you want to perform a dictionary attack, or remove dictEncoding param from command line.");
                        }
                        var encodingName = argument.Substring(13).Trim().ToLower();
                        switch (encodingName)
                        {
                            case "utf8":
                                crackSettings.DictionarySettings.Encoding = Encoding.UTF8;
                                break;
                            case "ascii":
                                crackSettings.DictionarySettings.Encoding = Encoding.ASCII;
                                break;
                            default:
                                crackSettings.DictionarySettings.Encoding = Encoding.Default;
                                break;
                        }
                    }
                    else if (argument.StartsWith("dictSkipLines", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.BruteForceSettings == null)
                        {
                            ShowError("Please provide -dictionary parameter if you want to perform a dictionary attack, or remove dictSkipLines param from command line.");
                        }
                        crackSettings.DictionarySettings.SkipLines = Int32.Parse(argument.Substring(14));
                    }
                    else if (argument.StartsWith("bruteForceStart", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.BruteForceSettings == null)
                        {
                            ShowError("Please provide -bruteForce parameter if you want to perform a brute force attack, or remove bruteForceStart param from command line.");
                        }
                        crackSettings.BruteForceSettings.StartPassword = argument.Substring(16);
                    }
                    else if (argument.StartsWith("bruteForceChars", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.BruteForceSettings == null)
                        {
                            ShowError("Please provide -bruteForce parameter if you want to perform a brute force attack, or remove bruteForceChars param from command line.");
                        }
                        crackSettings.BruteForceSettings.Chars = argument.Substring(16).ToCharArray();
                    }
                    else if (argument.StartsWith("bruteForceRegEx", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.BruteForceSettings == null)
                        {
                            ShowError("Please provide -bruteForce parameter if you want to perform a brute force attack, or remove bruteForceRegEx param from command line.");
                        }
                        crackSettings.BruteForceSettings.RegEx = new Regex(argument.Substring(16));
                    }
                    else if (argument.StartsWith("windowTitle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.WindowCrackSettings == null)
                        {
                            ShowError("Please do NOT provide file type parameter if you want to perform a window attack, or remove windowTitle param from command line.");
                        }
                        crackSettings.WindowCrackSettings.WindowTitle = argument.Substring(12);
                    }
                    else if (argument.StartsWith("errorWindowTitle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.WindowCrackSettings == null)
                        {
                            ShowError("Please do NOT provide file type parameter if you want to perform a window attack, or remove errorWindowTitle param from command line.");
                        }
                        crackSettings.WindowCrackSettings.ErrorWindowTitle = argument.Substring(17);
                    }
                    else if (argument.StartsWith("hasErrorMessage", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.WindowCrackSettings == null)
                        {
                            ShowError("Please do NOT provide file type parameter if you want to perform a window attack, or remove hasErrorMessage param from command line.");
                        }
                        crackSettings.WindowCrackSettings.HasErrorMessage = Boolean.Parse(argument.Substring(16));
                    }
                    else if (argument.StartsWith("exactErrorWindowTitleMatch", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.WindowCrackSettings == null)
                        {
                            ShowError("Please do NOT provide file type parameter if you want to perform a window attack, or remove exactErrorWindowTitleMatch param from command line.");
                        }
                        crackSettings.WindowCrackSettings.ExactErrorWindowTitleMatch = Boolean.Parse(argument.Substring(27));
                    }
                    else if (argument.StartsWith("waitForWindowInMs", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.WindowCrackSettings == null)
                        {
                            ShowError("Please do NOT provide file type parameter if you want to perform a window attack, or remove waitForWindowInMs param from command line.");
                        }
                        crackSettings.WindowCrackSettings.WaitForWindowInMs = Int32.Parse(argument.Substring(18));
                        if (crackSettings.WindowCrackSettings.WaitForWindowInMs > 100000)
                        {
                            ShowError("The provided waitForWindowInMs is too big.");
                        }
                    }
                    else if (argument.StartsWith("useSendKeysToCloseErrorWindow", StringComparison.OrdinalIgnoreCase))
                    {
                        if (crackSettings.WindowCrackSettings == null)
                        {
                            ShowError("Please do NOT provide file type parameter if you want to perform a window attack, or remove useSendKeysToCloseErrorWindow param from command line.");
                        }
                        crackSettings.WindowCrackSettings.UseSendKeysToCloseErrorWindow = true;
                    }
                }

                return crackSettings;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return null;
            }
        }

        private static void ShowError(string errorMessage)
        {
            Console.Error.WriteLine(errorMessage);
            Environment.Exit(1);
        }
    }
}
