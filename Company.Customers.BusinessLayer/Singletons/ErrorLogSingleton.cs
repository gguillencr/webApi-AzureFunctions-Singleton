using Company.Customers.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Customers.BusinessLayer.Singletons
{
    public sealed class ErrorLogSingleton
    {
        private static ErrorLogSingleton? instance;

        private ErrorLogSingleton() { }

        public static ErrorLogSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new ErrorLogSingleton();
                FileHelperSingleton fileHelperSingleton = FileHelperSingleton.GetInstance("SinglentonLog.txt");
                if (!fileHelperSingleton.FileExist())
                {
                    fileHelperSingleton.CreateFile();
                }
            }
            return instance;
        }

        public void SaveError(ErrorLogEntity errorLog)
        {
            FileHelperSingleton fileHelperSingleton = FileHelperSingleton.GetInstance("SinglentonLog.txt");
            fileHelperSingleton.Write(errorLog);
        }

        public List<ErrorLogEntity> GetErrors()
        {
            FileHelperSingleton fileHelperSingleton = FileHelperSingleton.GetInstance("SinglentonLog.txt");
            
            List<ErrorLogEntity> errors = new();
            string[] fileData = fileHelperSingleton.ReadFile();
            foreach (string line in fileData)
            {
                string[] tmpLine = line.Split(",");
                ErrorLogEntity entity = new() { Id = Guid.Parse(tmpLine[0].ToString()), Message = tmpLine[1], StackTrace = tmpLine[2] };
                errors.Add(entity);
            }
            return errors;
        }

        public ErrorLogEntity GetLastError()
        {
            FileHelperSingleton fileHelperSingleton = FileHelperSingleton.GetInstance("SinglentonLog.txt");
            
            List<ErrorLogEntity> errors = new();
            string[] fileData = fileHelperSingleton.ReadFile();
            foreach (string line in fileData)
            {
                string[] tmpLine = line.Split(",");
                ErrorLogEntity entity = new() { Id = Guid.Parse(tmpLine[0]), Message = tmpLine[1], StackTrace = tmpLine[2] };
                errors.Add(entity);
            }
            return errors.Last<ErrorLogEntity>();
        }

    }
}
