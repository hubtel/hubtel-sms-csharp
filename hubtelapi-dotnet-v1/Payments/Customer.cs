using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public class Customer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}