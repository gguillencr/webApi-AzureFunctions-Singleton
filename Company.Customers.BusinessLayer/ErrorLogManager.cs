using Company.Customers.BusinessLayer.Singletons;
using Company.Customers.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Customers.BusinessLayer
{
    public class ErrorLogManager
    {
        private readonly ErrorLogSingleton _errorLogSinglenton;

        public ErrorLogManager()
        {
            _errorLogSinglenton = ErrorLogSingleton.GetInstance();
        }

        public List<ErrorLogEntity> GetErrors() {
            return _errorLogSinglenton.GetErrors();
        }

        public ErrorLogEntity GetLastError()
        {
            return _errorLogSinglenton.GetLastError();
        }
    }
}
