using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Company.Customers.EntityLayer
{
    public class CustomerEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("givenName")]
        public string GivenName { get; set; } = String.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = String.Empty;
    }
}
