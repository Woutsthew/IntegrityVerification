using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace IntegrityVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            if (MyRegistry.IsRunAsAdmin() == true && args.Length == 0)
            {
                MyDataFile.CreateDataFile();
                MyRegistry.Install();
                return;
            }

            if (args.Length == 0)
                throw new ArgumentNullException("args");

            string command = String.Join(' ', args);

            if (command == Constants.INSTALL)
            {
                MyDataFile.CreateDataFile();
                MyRegistry.Install();
                return;
            }

            if (command == Constants.UNINSTALL)
            {
                MyRegistry.Uninstall();
                MyDataFile.DeleteDataFile();
                return;
            }


            if (File.Exists(Constants.dataFilePath) == false) MyDataFile.CreateDataFile();

            List<TrackedObject>  trackedObjects = JsonConvert.DeserializeObject<List<TrackedObject>>
                (File.ReadAllText(Constants.dataFilePath));


            if (File.Exists(command) == true)
            {
                Processing.WorkWithFile(trackedObjects, command);
                return;
            }

            if (Directory.Exists(command) == true)
            {
                // возможно 3 варианта вычислить hash директории
                // 1. объединяет хэши все файлов и вычисляет общий хэш
                // 2. вычисляет хэш всех файлов и добавляет в хэши в директорию (файлы прикрепленны к директории)
                // 3. вычисляет хэши всех файлов и сохраняет их как отдельные файлы
                // был выбран первый (1) вариант поскольку программа не преследует цель определить где именно было изменение

                Processing.WorkWithFolder(trackedObjects, command);
                return;
            }

            Console.WriteLine(Constants.FAIL); // info
        }
    }
}
