using System;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
   [Serializable] public class RecievePayment
    {
        public RecievePayment(string customerName, string customerMsisdn, string channel, decimal amount, string primaryCallbackUrl, string description, bool feesOnCustomer=false, string customerEmail = null, string secondaryCallBack = null, string clientReference = null, string token = null)
        {
            CustomerName = customerName;
            CustomerMsisdn = customerMsisdn;
            CustomerEmail = customerEmail;
            Channel = channel;
            Amount = amount;
            PrimaryCallbackUrl = primaryCallbackUrl;
            SecondaryCallbackUrl = secondaryCallBack;
            ClientReference = clientReference;
            Description = description;
            Token = token;
            FeesOnCustomer = feesOnCustomer;
        }


        public RecievePayment()
        {
           
        }
        [JsonProperty("FeesOnCustomer")] public bool FeesOnCustomer { get; set; }

        [JsonProperty("CustomerName")]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerMsisdn")]
        public string CustomerMsisdn { get; set; }

        [JsonProperty("CustomerEmail")]
        public string CustomerEmail { get; set; }

        [JsonProperty("Channel")]
        public string Channel { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("PrimaryCallbackUrl")]
        public string PrimaryCallbackUrl { get; set; }

        [JsonProperty("SecondaryCallbackUrl")]
        public string SecondaryCallbackUrl { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ClientReference")]
        public string ClientReference { get; set; }

        [JsonProperty("Token")]
        public string Token { get; set; }
    }
}