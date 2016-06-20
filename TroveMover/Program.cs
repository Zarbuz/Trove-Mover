using System;
using System.Collections.Generic;
using System.IO;

namespace TroveMover
{
    class Program
    {
        static void Main(string[] args)
        {
            string defaultPath = @"C:\Program Files (x86)\Steam\steamapps\common\Trove\Games\Trove\Live\qbexport\";
            Console.WriteLine("Is " + defaultPath + " the right folder ? (Y/N)");
            char res = Console.ReadKey().KeyChar;
            switch (res)
            {
                case 'Y':
                    Console.WriteLine("Remove all _a.qb files"); Remove(defaultPath, "*_a.qb");
                    Console.WriteLine("Remove all _s.qb files"); Remove(defaultPath, "*_s.qb");
                    Console.WriteLine("Remove all _t.qb files"); Remove(defaultPath, "*_t.qb");
                    Console.WriteLine("Remove all _t.qb files"); Remove(defaultPath, "*.blueprint");
                    Console.WriteLine("Order files"); SplitFolder(defaultPath);
                    break;
                case 'N':
                    Console.WriteLine("Path of all files : ");
                    string path = Console.ReadLine();
                    try
                    {
                        Console.WriteLine("Remove all _a.qb files"); Remove(path, "*_a.qb");
                        Console.WriteLine("Remove all _s.qb files"); Remove(path, "*_s.qb");
                        Console.WriteLine("Remove all _t.qb files"); Remove(path, "*_t.qb");
                        Console.WriteLine("Remove all _t.qb files"); Remove(path, "*.blueprint");
                        Console.WriteLine("Order files"); SplitFolder(path);
                    }
                    catch (Exception except)
                    {
                        Console.WriteLine(except.Message);
                    }
                    break;
                default:
                    Environment.Exit(0);
                    break;

            }

            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        static void Remove(string rootFolderPath, string filesToDelete)
        {
            List<String> fileList = DirSearch(rootFolderPath, filesToDelete);
            int countFiles = 0;
            foreach (string file in fileList)
            {
                Console.WriteLine(file + " will be deleted");
                countFiles++;
                File.Delete(file);
            }
            Console.WriteLine(countFiles + " files deleted");
        }
        static void SplitFolder(string rootFolderPath)
        {
            List<String> list = DirSearch(rootFolderPath);
            foreach (string file in list)
            {
                string fileName = Path.GetFileName(file);
                Console.WriteLine(file);
                string[] worldlist = fileName.Split('_');
                int countLevel = worldlist.Length;
                string pathToCheck = rootFolderPath;
                for (int i = 0; i < countLevel - 1; i++)
                {
                    pathToCheck += "\\" + worldlist[i];
                    //On en profite pour créer les dossiers
                    if (!Directory.Exists(pathToCheck))
                    {
                        Directory.CreateDirectory(pathToCheck);
                    }
                }

                if (!File.Exists(pathToCheck + "\\" + fileName)) //Si le fichier n'est pas là où il devrait se trouver
                {
                    //On le move dans ce dossier
                    Console.WriteLine("Move " + file + " to " + pathToCheck + "\\" + fileName);
                    File.Move(file, pathToCheck + "\\" + fileName);

                }
            }
        }

        static List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return files;
        }

        static List<String> DirSearch(string sDir, string patern)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir, patern))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d, patern));
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return files;
        }
    }
}
