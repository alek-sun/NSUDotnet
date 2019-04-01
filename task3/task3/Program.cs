using System;
using System.Collections.Generic;
using System.IO;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string extension = Console.ReadLine();
            List<CommentStructure> extensionsAvailable = new List<CommentStructure>();
            extensionsAvailable.Add(new JavaCommentStructure());

            StringCounter counter;
            try
            {
                counter = getStringCounter(extension, extensionsAvailable);
            }
            catch (CommentCounterException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Поиск файлов с раширением {extension} ...");
            long sumStrings = 0;
            int filesCount = 0;
            //get all files from this ditectory and subdirectories
            List<string> allFiles = GetFilesList(Directory.GetCurrentDirectory());
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

        private static StringCounter getStringCounter(string extension, List<CommentStructure> extensionsAvailable)
        {
            foreach (CommentStructure structure in extensionsAvailable)
            {
                if (structure.GetExtensions().Contains(extension))
                {
                     return new StringCounter(structure);
                }
            }
            throw new CommentCounterException("Extension not supported");
        }

        static List<string> GetFilesList(string path)
        {
            List<string> filesList = new List<string>();
            string[] dirs = Directory.GetDirectories(path);
            filesList.AddRange(Directory.GetFiles(path));
            foreach (string subdirectory in dirs)
            {
                try
                {
                    filesList.AddRange(GetFilesList(subdirectory));
                }
                catch { }
            }

            return filesList;
        }
    }
}
