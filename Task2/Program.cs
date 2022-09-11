using System;
using System.IO;

/*
 * Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами). 
 * На вход метод принимает URL директории, в ответ — размер в байтах.
 *  C:\\Users\\admin\\Desktop\\SkillFactory
 * */
namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = EnterPath();
            if (path.Exists)
            {
                long result = CountFiles(path);
                Console.WriteLine("Общий вес: " + result);
            }

        }

        // Вводится путь 
        static DirectoryInfo EnterPath()
        {
            Console.WriteLine("Введите путь до папки, например C:\\Users\\Lenovo\\OneDrive\\Рабочий стол\\SkillFactory");
            string path = Console.ReadLine();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            return dirInfo;
        }

        static long CountFiles(DirectoryInfo path)
        {
            long size = 0;

            DirectoryInfo[] infos = path.GetDirectories();
            FileInfo[] arr = path.GetFiles();
            foreach (FileInfo fi in arr)
            {

                size += fi.Length;
            }
            foreach (DirectoryInfo info in infos)
            {
                size += CountFiles(info);
            }

            return size;
        }
    }
}
