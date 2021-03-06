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
            string command = String.Join(' ', args);

            if (File.Exists(Constants.dataFilePath) == false)
                File.Create(Constants.dataFilePath).Close();

            if (String.IsNullOrEmpty(File.ReadAllText(Constants.dataFilePath)))
                File.WriteAllText(Constants.dataFilePath, JsonConvert.SerializeObject(new List<TrackedObject>(), Formatting.Indented));

            List<TrackedObject> trackedObjects = JsonConvert.DeserializeObject<List<TrackedObject>>(File.ReadAllText(Constants.dataFilePath));


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
        }
    }
}
