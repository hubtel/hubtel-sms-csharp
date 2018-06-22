// ***********************************************************************
// <copyright file="SendPayment.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class SendPayment.
    /// </summary>
    public class SendPayment
    {



        /// <summary>
        /// Initializes a new instance of the <see cref="SendPayment"/> class.
        /// </summary>
        /// <param name="recipientName">Name of the recipient.</param>
        /// <param name="recipientMsisdn">The recipient msisdn.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="customerEmail">The customer email.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="primaryCallbackUrl">The primary callback URL.</param>
        /// <param name="description">The description.</param>
        /// <param name="secondaryCallbackUrl">The secondary callback URL.</param>
        /// <param name="clientReference">The client reference.</param>
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

        /// <summary>
        /// Gets or sets the name of the recipient.
        /// </summary>
        /// <value>The name of the recipient.</value>
        public string RecipientName{ get; set; }
        /// <summary>
        /// Gets or sets the recipient msisdn.
        /// </summary>
        /// <value>The recipient msisdn.</value>
        public string RecipientMsisdn { get; set; }
        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        /// <value>The channel.</value>
        public string Channel { get; set; }
        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>The customer email.</value>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the primary callback URL.
        /// </summary>
        /// <value>The primary callback URL.</value>
        public string PrimaryCallbackUrl { get; set; }
        /// <summary>
        /// Gets or sets the secondary callback URL.
        /// </summary>
        /// <value>The secondary callback URL.</value>
        public string SecondaryCallbackUrl { get; set; }
        /// <summary>
        /// Gets or sets the client reference.
        /// </summary>
        /// <value>The client reference.</value>
        public string ClientReference { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
    }
}
