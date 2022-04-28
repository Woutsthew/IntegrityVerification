using System.IO;
using IVInstall.Properties;

namespace IVInstall
{
    class MyDataFile
    {
        public static bool CreateFile()
        {
            Directory.CreateDirectory(Constants.appDirectoryPath);

            if (File.Exists(Constants.appFilePath) == false)
                File.WriteAllBytes(Constants.appFilePath, Resources.IntegrityVerification);

            if (File.Exists(Constants.dataFilePath) == false)
                File.Create(Constants.dataFilePath).Close();

            if (File.Exists(Constants.uninstallFilePath) == false)
                File.WriteAllBytes(Constants.uninstallFilePath, Resources.Uninstall);

            return true;
        }
    }
}
