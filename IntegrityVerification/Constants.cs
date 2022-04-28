using System;
using System.Diagnostics;
using System.IO;

namespace IntegrityVerification
{
    static class Constants
    {
        private static string appFileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
        private const string dataFileName = "TrackedObjects.txt";

        private static readonly string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string appDirectoryPath = Path.Combine(Constants.roaming, Process.GetCurrentProcess().ProcessName);
        public static readonly string appFilePath = Path.Combine(Constants.appDirectoryPath, appFileName);
        public static readonly string dataFilePath = Path.Combine(Constants.appDirectoryPath, Constants.dataFileName);
    }
}
