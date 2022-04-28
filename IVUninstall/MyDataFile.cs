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
                    Arguments = $"/C timeout /T 3 & rd /s/q {Constants.appDirectoryPath}",
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                });
            }

            return true;
        }
    }
}
