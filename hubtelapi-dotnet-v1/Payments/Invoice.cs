using System.Collections.Generic;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public class Invoice
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("taxes")]
        public List<Tax> Taxes { get; set; }

        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}