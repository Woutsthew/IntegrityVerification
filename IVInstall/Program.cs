using System.Runtime.Versioning;

namespace IVInstall
{
    class Program
    {
        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            MyRegistry.CreateSubKey();
            MyDataFile.CreateFile();
        }
    }
}
