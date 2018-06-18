namespace hubtelapi_dotnet_v1.Payments
{
    public class SendPayment
    {

       

        public SendPayment(string recipientName, string recipientMsisdn, string channel, string customerEmail, decimal amount, string primaryCallbackUrl, string description, string secondaryCallbackUrl = null, string clientReference = null)
        {
            RecipientName = recipientName;
            RecipientMsisdn = recipientMsisdn;
            Channel = channel;
            CustomerEmail = customerEmail;
            Amount = amount;
            PrimaryCallbackUrl = primaryCallbackUrl;
            SecondaryCallbackUrl = secondaryCallbackUrl;
            ClientReference = clientReference;
            Description = description;
        }

        public string RecipientName{ get; set; }
        public string RecipientMsisdn { get; set; }
        public string Channel { get; set; }
        public string CustomerEmail { get; set; }
        public decimal Amount { get; set; }
        public string PrimaryCallbackUrl { get; set; }
        public string SecondaryCallbackUrl { get; set; }
        public string ClientReference { get; set; }
        public string Description { get; set; }
    }
}
