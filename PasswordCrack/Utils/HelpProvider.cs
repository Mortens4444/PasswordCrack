using System;

namespace PasswordCrack.Utils
{
    public static class HelpProvider
    {
        public static void ShowHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine();
            Console.WriteLine("  General");
            Console.WriteLine("  -------");
            Console.WriteLine("  -help, -h, -sos, -101: Display this help message.");
            Console.WriteLine("  -casePermutations: (Optional) Use case permutations, default is false");
            Console.WriteLine("  -openFileWhenStart: (Optional) Open file before cracking starts, default is false");
            Console.WriteLine();
            Console.WriteLine("  File Settings");
            Console.WriteLine("  -------------");
            Console.WriteLine("  -word\r\n   Crack a Word document (e.g., -word -file:\"C:\\example.docx\")\r\n");
            Console.WriteLine("  -pdf\r\n   Crack a PDF file (e.g., -pdf -file:\"C:\\example.pdf\")\r\n");
            Console.WriteLine("  -excel\r\n   Crack an Excel file (e.g., -excel -file:\"C:\\example.xlsx\")\r\n");
            Console.WriteLine("  -zip\r\n   Crack a Zip file (e.g., -zip -file:\"C:\\example.zip\")\r\n");
            Console.WriteLine("  -file:<path>\r\n   Specify the file to crack (e.g., -file:\"C:\\path\\to\\file.pdf\")");
            Console.WriteLine();
            Console.WriteLine("  Brute Force Settings");
            Console.WriteLine("  --------------------");
            Console.WriteLine("  -bruteForce\r\n   (Required) Perform a brute force attack\r\n");
            Console.WriteLine("  -bruteForceStart:<password>\r\n   Specify the starting password for brute force (e.g., -bruteForceStart:abc123)\r\n");
            Console.WriteLine("  -bruteForceChars:<chars>\r\n   Specify characters for brute force attack (e.g., -bruteForceChars:abcd1234)\r\n");
            Console.WriteLine("  -bruteForceRegEx:<pattern>\r\n   Specify a regular expression for the brute force attack (e.g., -bruteForceRegEx:\\d{4}\\.\\d{2}\\.\\d{2})");
            Console.WriteLine();
            Console.WriteLine("  Dictionary Settings");
            Console.WriteLine("  -------------------");
            Console.WriteLine("  -dictionary\r\n   (Required) Perform a dictionary attack\r\n");
            Console.WriteLine("  -dictFile:<path>\r\n   (Optional) Use a dictionary file for cracking (e.g., -dictFile:\"C:\\path\\to\\dictionary.txt\"), use embedded password file if not provided\r\n");
            Console.WriteLine("  -dictEncoding:<encoding>\r\n   (Optional) Specify the encoding of the dictionary file (e.g., -dictEncoding:utf8)\r\n");
            Console.WriteLine("  -dictSkipLines:<number>\r\n   (Optional) Skip the specified number of lines in the dictionary file (e.g., -dictSkipLines:5)");
            Console.WriteLine();
            Console.WriteLine("  Window Attack Settings (Default attack when file type is not set)");
            Console.WriteLine("  -----------------------------------------------------------------");
            Console.WriteLine("  -adobeWindow\r\n  Loads Adobe Acrobat Reader window default settings\r\n");
            Console.WriteLine("  -libreOfficeWindow\r\n  Loads Libre Office window default settings\r\n");
            Console.WriteLine("  -totalCommanderWindow\r\n  Loads Total Commander window default settings\r\n");
            Console.WriteLine("  -windowsExplorerWindow\r\n  Loads Windows Explorer window default settings\r\n");
            Console.WriteLine("  -windowTitle:<title>\r\n  Title of the password requester window\r\n");
            Console.WriteLine("  -errorWindowTitle:<title>\r\n  Title of the error message displayed on failure\r\n");
            Console.WriteLine("  -hasErrorMessage:<boolean>\r\n   True if an error message is shown when a wrong password is provided. The default value is true.\r\n");
            Console.WriteLine("  -exactErrorWindowTitleMatch:<boolean>\r\n    True if the error message exactly matches the provided errorWindowTitle. The default value is true. If changed to false, the program will search for the windows, which could cause performance issues.\r\n");
            Console.WriteLine("  -waitForWindowInMs:<number>\r\n    Milliseconds to wait for a window to appear.\r\n");
            Console.WriteLine("  -useSendKeysToCloseErrorWindow\r\n    The default behavior is to send a WM_CLOSE request to the error window, but it can be modified to send an Enter key press using SendKeys.");
            Console.WriteLine();
            Console.WriteLine("  Example");
            Console.WriteLine("  -------");
            Console.WriteLine("  PasswordCrack -pdf -file:\"C:\\Encrypted.pdf\" -dictionary -dictEncoding:utf8 -dictSkipLines:20 -bruteForce -bruteForceStart:password123\r\n   This command will perform a Dictionary attack with the embedded password file, and a brute force attack, the password not found by the dictionary attack.\r\n");
            Console.WriteLine("  PasswordCrack -pdf -file:\"E:\\Data\\Encrypted.pdf\"  -bruteForce -bruteForceStart:1980.01.01 -bruteForceChars:0123456789. -bruteForceRegEx:^(?:19[0-9]{2}|20[0-1][0-9]|202[0-4])\\.(0[1-9]|1[0-2])\\.(0[1-9]|[12][0-9]|3[01])$\r\n   This command will perform a brute force attack with a date regular expression from 1980.01.01 to 2024.12.31.");

            Environment.Exit(0);
        }
    }
}
