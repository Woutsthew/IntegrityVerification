using Microsoft.Win32;
using System.Runtime.Versioning;

namespace IVUninstall
{
    static class MyRegistry
    {
        [SupportedOSPlatform("windows")]
        public static bool DeleteSubKey()
        {
            Delete(Registry.ClassesRoot, "*");
            Delete(Registry.ClassesRoot, "Folder");

            return true;

            static bool Delete(RegistryKey classesRoot, string subKey)
            {
                RegistryKey shell = classesRoot.OpenSubKey(subKey).OpenSubKey(Constants.r_SHELL, true);

                if (shell.OpenSubKey(Constants.appName) != null)
                    shell.DeleteSubKeyTree(Constants.appName);

                shell.Close();

                return true;
            }
        }
    }
}
