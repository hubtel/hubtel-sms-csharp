using System;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public  class Datum
    {
        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("TransactionStatus")]
        public string TransactionStatus { get; set; }

        [JsonProperty("TransactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("NetworkTransactionId")]
        public string NetworkTransactionId { get; set; }

        [JsonProperty("InvoiceToken")]
        public string InvoiceToken { get; set; }

        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("PaymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("ClientReference")]
        public string ClientReference { get; set; }

        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("TransactionAmount")]
        public double TransactionAmount { get; set; }

        [JsonProperty("Fee")]
        public double? Fee { get; set; }

        [JsonProperty("AmountAfterFees")]
        public double AmountAfterFees { get; set; }

        [JsonProperty("CardSchemeName")]
        public object CardSchemeName { get; set; }

        [JsonProperty("CardNumber")]
        public object CardNumber { get; set; }

        [JsonProperty("MobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("MobileChannelName")]
        public string MobileChannelName { get; set; }

        [JsonProperty("TransactionCycle")]
        public TransactionCycle[] TransactionCycle { get; set; }

        [JsonProperty("RelatedTransactionId")]
        public object RelatedTransactionId { get; set; }

        [JsonProperty("RelatedTransactionType")]
        public object RelatedTransactionType { get; set; }

        [JsonProperty("Disputed")]
        public bool Disputed { get; set; }

        [JsonProperty("DisputedAmount")]
        public long DisputedAmount { get; set; }

        [JsonProperty("DisputedAmountFee")]
        public long DisputedAmountFee { get; set; }

        [JsonProperty("TotalAmountRefunded")]
        public long TotalAmountRefunded { get; set; }
    }
}