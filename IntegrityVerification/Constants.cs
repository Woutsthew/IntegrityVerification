using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace IntegrityVerification
{
    static class Constants
    {
        private static string appFileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
        private const string dataFileName = "TrackedObjects.txt";

        private static readonly string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string appDirectoryPath = Path.Combine(Constants.roaming, Process.GetCurrentProcess().ProcessName);
        public static readonly string appFilePath = Path.Combine(Constants.appDirectoryPath, appFileName);
        public static readonly string dataFilePath = Path.Combine(Constants.appDirectoryPath, Constants.dataFileName);


        public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> items, int chunkSize)
        {
            using (var enumerator = items.GetEnumerator())
                while (enumerator.MoveNext())
                    yield return TakeN(enumerator, chunkSize);
        }

        static IEnumerable<T> TakeN<T>(IEnumerator<T> enumerator, int chunkSize)
        {
            for (var i = 0; i < chunkSize; i++)
            {
                yield return enumerator.Current;
                if (!enumerator.MoveNext())
                    break;
            }
        }
    }
}
