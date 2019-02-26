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

            List<string> allFiles = GetFilesList(Directory.GetCurrentDirectory());
            foreach (string f in allFiles){
                Console.WriteLine(Path.GetExtension(f));
            }
           
            Console.ReadLine();
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
