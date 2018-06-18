using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public class InvoiceResponse
    {
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("response_text")]
        public string ResponseText { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}