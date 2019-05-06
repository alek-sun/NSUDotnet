using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace task3
{
    class CommentCounter
    {
        public void Start()
        {
            var extension = Console.ReadLine();
            var extensionsAvailable = new List<ICommentStructure>();
            extensionsAvailable.Add(new JavaCommentStructure());

            StringCounter counter;
            
            counter = GetStringCounter(extension, extensionsAvailable);
            
            Console.WriteLine($"Поиск файлов с раширением {extension} ...");
            var sumStrings = 0;
            var filesCount = 0;
            //get all files from this ditectory and subdirectories
            var allFiles = GetFilesList(Directory.GetCurrentDirectory());
            foreach (string fileName in allFiles)
            {
                if (Path.GetExtension(fileName) == extension)
                {
                    Console.WriteLine(fileName);
                    sumStrings += counter.GetStringsCount(fileName);
                    filesCount++;
                }
            }

            Console.WriteLine($"Файлов найдено: {filesCount}\r\nЧисло осмысленных строк в них : {sumStrings}");

            Console.ReadLine();
        }

        private static StringCounter GetStringCounter(string extension, List<ICommentStructure> extensionsAvailable)
        {
            foreach (var structure in extensionsAvailable)
            {
                if (structure.Extensions.Contains(extension))
                {
                    return new StringCounter(structure);
                }
            }
            return null;
        }

        static List<string> GetFilesList(string path)
        {
            var filesList = new List<string>();
            var dirs = Directory.GetDirectories(path);
            filesList.AddRange(Directory.GetFiles(path));
            foreach (string subdirectory in dirs)
            {
                filesList.AddRange(GetFilesList(subdirectory));
            }

            return filesList;
        }
    }
}
