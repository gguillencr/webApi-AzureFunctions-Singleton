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
        public bool CreateCustomer(CustomerEntity customer)
        {
            try
            {
                throw new NotImplementedException();
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogSingleton errorLogSingleton = ErrorLogSingleton.GetInstance();
                errorLogSingleton.SaveError(new ErrorLogEntity() { Message = ex.Message, StackTrace = ex.StackTrace! });
                return false;
            }
            
        }
    }
}
