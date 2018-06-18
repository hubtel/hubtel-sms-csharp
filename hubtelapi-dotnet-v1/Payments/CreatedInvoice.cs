using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public class CreatedInvoice
    {
        [JsonProperty("invoice")]
        public Invoice Invoice { get; set; }

        [JsonProperty("store")]
        public Store Store { get; set; }

        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        [JsonProperty("actions")]
        public Actions Actions { get; set; }
        


    }

}