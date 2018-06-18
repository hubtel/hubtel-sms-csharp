namespace hubtelapi_dotnet_v1.Payments
{
    public class Transaction
    {
        public string InvoiceToken { get; set; }
        public string NetworkTransactionId { get; set; }
        public string HubtelTransactionId { get; set; } 
    }
}