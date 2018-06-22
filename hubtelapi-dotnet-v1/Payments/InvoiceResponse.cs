using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public class InvoiceResponse
    {
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("response_text")]
        public string ResponseText { get; set; }

        [JsonProperty("invoice")]
        public Invoice Invoice { get; set; }

        [JsonProperty("actions")]
        public Actions Actions { get; set; }

        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("receipt_url")]
        public string ReceiptUrl { get; set; }
    }
}