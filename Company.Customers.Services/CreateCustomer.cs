using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Company.Customers.EntityLayer;
using Company.Customers.BusinessLayer;

namespace Company.Customers.Services
{
    public static class CreateCustomer
    {
        [FunctionName("CreateCustomer")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "api/customer/create")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("api/customer/create processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CustomerEntity customerEntity = JsonConvert.DeserializeObject<CustomerEntity>(requestBody);

            CustomersManager customersManager = new();
            bool result = customersManager.CreateCustomer(customerEntity);

            return new OkObjectResult(new { Result = result});
        }
    }
}
