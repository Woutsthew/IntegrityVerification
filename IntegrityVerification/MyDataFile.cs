using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace IntegrityVerification
{
    static class MyDataFile
    {
        public static bool CreateDataFile()
        {
            Directory.CreateDirectory(Constants.appDirectoryPath);

            if (File.Exists(Constants.dataFilePath) == false)
            {
                if (File.Exists(Constants.appFilePath) == false)
                    File.Copy(Process.GetCurrentProcess().MainModule.FileName, Constants.appFilePath);

                File.Create(Constants.dataFilePath).Close();
                File.WriteAllText(Constants.dataFilePath, JsonConvert.SerializeObject(new List<TrackedObject>(), Formatting.Indented));
            }

            return true;
        }

        public static bool DeleteDataFile()
        {
            if (Directory.Exists(Constants.appDirectoryPath) == true)
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = $"/C timeout /T 3 & rd /s/q {Constants.appDirectoryPath}",
                    FileName = "cmd.exe", WindowStyle = ProcessWindowStyle.Hidden, CreateNoWindow = true
                });
                //Directory.Delete(Constants.appDirectoryPath, true);
            }

            return true;
        }
    }
}
