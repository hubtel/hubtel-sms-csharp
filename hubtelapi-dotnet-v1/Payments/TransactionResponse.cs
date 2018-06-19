using System.Collections.Generic;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public class TransactionResponse
    {
        [JsonProperty("ResponseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("Data")]
        public List<Datum> Data { get; set; }

        
    }
}