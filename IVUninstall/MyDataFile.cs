using System.Diagnostics;
using System.IO;

namespace IVUninstall
{
    static class MyDataFile
    {
        public static bool DeleteFile()
        {
            if (Directory.Exists(Constants.appDirectoryPath) == true)
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    CreateNoWindow = true,
                    Arguments = $"/c timeout /t 3 & rd /s /q {Constants.appDirectoryPath}"
                });
            }

            return true;
        }
    }
}
