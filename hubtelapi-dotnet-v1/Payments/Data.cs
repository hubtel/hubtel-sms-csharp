namespace hubtelapi_dotnet_v1.Payments
{
    public class Data
    {
        public decimal AmountAfterCharges { get; set; }
        public string TransactionId { get; set; }
        public string ClientReference { get; set; }
        public string Description { get; set; }
        public string ExternalTransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Charges { get; set; }

    }
}