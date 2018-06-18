using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public  class Actions
    {
        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
    }
}