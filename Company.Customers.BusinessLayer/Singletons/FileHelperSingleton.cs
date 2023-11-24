using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Customers.BusinessLayer.Singletons
{
    public sealed class FileHelperSingleton
    {
        private static FileHelperSingleton? instance;
        private static string? _path;

        private FileHelperSingleton() { }

        public static FileHelperSingleton GetInstance(string path)
        {
            _path = path;

            if (instance == null)
            {
                instance = new FileHelperSingleton();
            }
            return instance;
        }

        public bool FileExist() => File.Exists(_path);

        public FileStream CreateFile() => File.Create(_path!);
        
        public void Write(object objectToSave)
        {
            using StreamWriter sw = new(_path!, true);
            sw.WriteLine(objectToSave.ToString());
        }

        public string[] ReadFile() => File.ReadAllLines(_path!);
    }
}
