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
                File.Create(Constants.dataFilePath).Close();
                File.WriteAllText(Constants.dataFilePath, JsonConvert.SerializeObject(new List<TrackedObject>(), Formatting.Indented));
                File.Copy(Process.GetCurrentProcess().MainModule.FileName,
                    Path.Combine(Constants.appDirectoryPath, Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName)));
            }

            return true;
        }

        public static bool DeleteDataFile()
        {
            if (Directory.Exists(Constants.appDirectoryPath) == true)
                Directory.Delete(Constants.appDirectoryPath, true);

            return true;
        }
    }
}
