using System;
using System.IO;

namespace IVUninstall
{
    static class Constants
    {
        public const string r_SHELL = "shell";


        public static string appName = "IntegrityVerification";

        private static readonly string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string appDirectoryPath = Path.Combine(Constants.roaming, Constants.appName);
    }
}
