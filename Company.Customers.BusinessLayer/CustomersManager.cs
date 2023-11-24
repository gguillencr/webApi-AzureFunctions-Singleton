using Company.Customers.BusinessLayer.Singletons;
using Company.Customers.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Customers.BusinessLayer
{
    public class CustomersManager
    {
        private readonly ErrorLogSingleton _errorLogSingleton;
        public CustomersManager() {
            _errorLogSingleton = ErrorLogSingleton.GetInstance();
        }

        public bool CreateCustomer(CustomerEntity customer)
        {
            try
            {
                throw new NotImplementedException(); //exception thrown for testing the Singleton
                //login for creating a customer should be here
                return true;
            }
            catch (Exception ex)
            {
                _errorLogSingleton.SaveError(new ErrorLogEntity() { Message = ex.Message, StackTrace = ex.StackTrace! });
                return false;
            }
            
        }
    }
}
