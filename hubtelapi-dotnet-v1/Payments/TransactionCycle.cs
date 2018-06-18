using System;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public partial class TransactionCycle
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }
    }
}