using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public  class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("unit_price")]
        public string UnitPrice { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}