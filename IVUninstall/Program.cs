using System.Runtime.Versioning;

namespace IVUninstall
{
    class Program
    {
        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            MyRegistry.DeleteSubKey();
            MyDataFile.DeleteFile();
        }
    }
}
