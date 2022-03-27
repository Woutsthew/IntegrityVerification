using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace IntegrityVerification
{
    class Program
    {
        static List<TrackedObject> trackedObjects;

        static void Main(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentNullException("args");

            string command = String.Join(' ', args);

            if (command == Constants.INSTALL)
            {
                MyRegistry.Install();
                MyDataFile.CreateDataFile();
                return;
            }

            if (command == Constants.UNINSTALL)
            {
                MyRegistry.Uninstall();
                MyDataFile.DeleteDataFile();
                return;
            }

            trackedObjects = JsonConvert.DeserializeObject<List<TrackedObject>>
                (File.ReadAllText(Constants.dataFilePath));

            if (File.Exists(command) == true)
            {
                WorkWithFile(command);
                return;
            }

            //if (Directory.Exists(command) == true) { return; }

            Console.WriteLine(Constants.FAIL); // info
            Console.ReadLine();
        }

        static bool WorkWithFile(string pathObj)
        {
            var obj = trackedObjects.Find(x => x.path == pathObj);
            byte[] bytes = File.ReadAllBytes(pathObj);
            string hash = Cryptograhy.Sha256(bytes);

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
