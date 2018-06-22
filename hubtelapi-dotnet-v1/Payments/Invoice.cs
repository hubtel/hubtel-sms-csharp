using System.Collections.Generic;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public class Invoice
    {
        [JsonProperty("total_amount")]
        public double TotalAmount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}