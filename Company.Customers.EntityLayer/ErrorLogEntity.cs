using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Company.Customers.EntityLayer
{
    public class ErrorLogEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Message { get; set; } = string.Empty;

        public string StackTrace { get; set; } = string.Empty;

        override
        public string ToString() {
            return $"{Id},{Message},{StackTrace}";
        }
    }
}
