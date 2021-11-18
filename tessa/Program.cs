using System;
using System.IO;
using System.Linq;

namespace tessa
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите имя папаки с которго надо скопировать фаилы: (FromTessa)");
            string fromFolder = readAndCheckFolderName("FromTessa");

            string[] allfiles = Directory.GetFiles(fromFolder);

            if (!allfiles.Any())
            {
                Console.WriteLine("В папке нет файлов\n");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Введите имя папаки куда надо скопировать фаилы:(ToTessa)");
            string toFolder = readAndCheckFolderName("ToTessa");

            foreach (var longFileName in allfiles)
            {
                string shotFileName = longFileName.Split('\\')[1];
                try {
                    File.Copy(longFileName, $"{toFolder}/{shotFileName}");
                    Console.WriteLine("Файл с именем {0} скопирован в папку {1}", shotFileName, toFolder);
                }
                catch (IOException)
                {
                    Console.WriteLine("Файл с именем {0} уже существует в папке {1}", shotFileName, toFolder);
                }
                catch (Exception)
                {
                    Console.WriteLine("Что то пошло не так при копирований файла {0}", shotFileName);
                }
            }

            Console.ReadLine();
        }

        static private string readAndCheckFolderName(string defaultName)
        {
            string read = Console.ReadLine().Trim();
            string folderToName = read == "" ? defaultName : read;
            if (!Directory.Exists(folderToName))
            {
                Directory.CreateDirectory(folderToName);
            }

            return folderToName;
        }
    }
}
