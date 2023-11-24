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
using System.Collections.Generic;
using Company.Customers.EntityLayer;

namespace Company.Customers.Services
{
    public static class GetErrors
    {
        [FunctionName("GetErrors")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "api/log")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("api/log processed a request.");

            ErrorLogManager errorLogManager = new();
            List<ErrorLogEntity> errors = errorLogManager.GetErrors();

            return new OkObjectResult(new { Result = errors});
        }
    }
}
