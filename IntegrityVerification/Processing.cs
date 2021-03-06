using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrityVerification
{
    static class Processing
    {
        public static bool WorkWithFile(List<TrackedObject> trackedObjects, string pathObj)
        {
            var obj = trackedObjects.Find(x => x.path == pathObj);
            string hash = FamilySHA.SHA256(File.ReadAllBytes(pathObj));

            ProcessDistribution(trackedObjects, obj, pathObj, hash);

            return true;
        }

        public static bool WorkWithFolder(List<TrackedObject> trackedObjects, string pathObj)
        {
            var obj = trackedObjects.Find(x => x.path == pathObj);
            StringBuilder hashs = new StringBuilder();

            foreach (string filepath in Directory.EnumerateFiles(pathObj, "*.*", SearchOption.AllDirectories))
                hashs.Append(FamilySHA.SHA256(File.ReadAllBytes(filepath)));

            string sumHash = FamilySHA.SHA256(hashs.ToString());

            ProcessDistribution(trackedObjects, obj, pathObj, sumHash);

            return true;
        }

        private static bool ProcessDistribution(List<TrackedObject> trackedObjects, TrackedObject obj, string pathObj, string hash)
        {
            if (obj == null)
            {
                trackedObjects.Add(new TrackedObject(pathObj, hash)); // добавление нового объекта
            }
            else
            {
                if (obj.hashes.Last() != hash)
                {
                    obj.hashes.Add(hash); // хэши отличаються
                }
                else
                {
                    // хэш остался таким же
                }
            }

            File.WriteAllText(Constants.dataFilePath, JsonConvert.SerializeObject(trackedObjects, Formatting.Indented));

            return true;
        }
    }
}
