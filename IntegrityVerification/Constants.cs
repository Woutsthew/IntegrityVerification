using System;
using System.Diagnostics;
using System.IO;

namespace IntegrityVerification
{
    static class Constants
    {
        public const string INSTALL = "install";
        public const string UNINSTALL = "uninstall";

        public const string SUCCESS = "Success";
        public const string FAIL = "Fail";


        public const string r_SHELL = "shell";

        public const string r_MUIVerb = "MUIVerb";
        public const string r_MUIVerbValue = "Check hash";

        public const string r_ICON = "icon";

        public const string r_COMMAND = "command";


        private static string appFileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
        private const string dataFileName = "TrackedObjects.txt";

        private static readonly string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string appDirectoryPath = Path.Combine(Constants.roaming, Process.GetCurrentProcess().ProcessName);
        public static readonly string appFilePath = Path.Combine(Constants.appDirectoryPath, appFileName);
        public static readonly string dataFilePath = Path.Combine(Constants.appDirectoryPath, Constants.dataFileName);
    }
}
