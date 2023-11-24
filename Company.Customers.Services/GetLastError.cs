using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Company.Customers.BusinessLayer;
using Company.Customers.EntityLayer;

namespace Company.Customers.Services
{
    public static class GetLastError
    {
        [FunctionName("GetLastError")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "api/log/last")] HttpRequest req,
            ILogger log)
        {
            
            ErrorLogManager errorLogManager = new();
            ErrorLogEntity errorLogEntry = errorLogManager.GetLastError();

            return new OkObjectResult(new { Result = errorLogEntry });
        }
    }
}
