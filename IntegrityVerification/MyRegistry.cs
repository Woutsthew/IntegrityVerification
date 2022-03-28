using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Security.Principal;

namespace IntegrityVerification
{
    static class MyRegistry
    {
        public static bool Install()
        {
            Create(Registry.ClassesRoot, "*");
            Create(Registry.ClassesRoot, "Folder");

            return true;

            static bool Create(RegistryKey classesRoot, string subKey)
            {
                RegistryKey shell = classesRoot.OpenSubKey(subKey).OpenSubKey(Constants.r_SHELL, true);

                RegistryKey app = shell.CreateSubKey(Process.GetCurrentProcess().ProcessName, true);
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

        public static bool Uninstall()
        {
            Delete(Registry.ClassesRoot, "*");
            Delete(Registry.ClassesRoot, "Folder");

            return true;

            static bool Delete(RegistryKey classesRoot, string subKey)
            {
                RegistryKey shell = classesRoot.OpenSubKey(subKey).OpenSubKey(Constants.r_SHELL, true);

                if (shell.OpenSubKey(Process.GetCurrentProcess().ProcessName) != null)
                    shell.DeleteSubKeyTree(Process.GetCurrentProcess().ProcessName);

                shell.Close();

                return true;
            }
        }

        public static bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
