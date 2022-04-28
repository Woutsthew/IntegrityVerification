using Microsoft.Win32;
using System.Runtime.Versioning;

namespace IVInstall
{
    static class MyRegistry
    {
        [SupportedOSPlatform("windows")]
        public static bool CreateSubKey()
        {
            Create(Registry.ClassesRoot, "*");
            Create(Registry.ClassesRoot, "Folder");

            return true;

            static bool Create(RegistryKey classesRoot, string subKey)
            {
                RegistryKey shell = classesRoot.OpenSubKey(subKey).OpenSubKey(Constants.r_SHELL, true);

                RegistryKey app = shell.CreateSubKey(Constants.appName, true);
                app.SetValue(Constants.r_MUIVerb, Constants.r_MUIVerbValue);
                app.SetValue(Constants.r_ICON, Constants.appFilePath);

                RegistryKey command = app.CreateSubKey(Constants.r_COMMAND);
                command.SetValue("", $"\"{Constants.appFilePath}\" %1");

                command.Close();
                app.Close();
                shell.Close();

                return true;
            }
        }
    }
}
