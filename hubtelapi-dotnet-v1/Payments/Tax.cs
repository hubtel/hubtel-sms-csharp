using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public class Tax
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}