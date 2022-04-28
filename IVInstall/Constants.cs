using System;
using System.IO;

namespace IVInstall
{
    static class Constants
    {
        public const string r_SHELL = "shell";

        public const string r_MUIVerb = "MUIVerb";
        public const string r_MUIVerbValue = "Check hash";

        public const string r_ICON = "icon";

        public const string r_COMMAND = "command";


        public static string appName = "IntegrityVerification";
        private static string appFileName = $"{Constants.appName}.exe";
        private const string dataFileName = "TrackedObjects.txt";
        private const string uninstallFileName = "Uninstall.exe";

        private static readonly string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string appDirectoryPath = Path.Combine(Constants.roaming, Constants.appName);

        public static readonly string appFilePath = Path.Combine(Constants.appDirectoryPath, appFileName);
        public static readonly string dataFilePath = Path.Combine(Constants.appDirectoryPath, Constants.dataFileName);
        public static readonly string uninstallFilePath = Path.Combine(Constants.appDirectoryPath, Constants.uninstallFileName);
    }
}
