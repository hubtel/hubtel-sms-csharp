// ***********************************************************************
// <copyright file="RecievePayment.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class RecievePayment.
    /// </summary>
    [Serializable] public class RecievePayment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecievePayment"/> class.
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="customerMsisdn">The customer msisdn.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="primaryCallbackUrl">The primary callback URL.</param>
        /// <param name="description">The description.</param>
        /// <param name="feesOnCustomer">if set to <c>true</c> [fees on customer].</param>
        /// <param name="customerEmail">The customer email.</param>
        /// <param name="secondaryCallBack">The secondary call back.</param>
        /// <param name="clientReference">The client reference.</param>
        /// <param name="token">The token.</param>
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


        /// <summary>
        /// Initializes a new instance of the <see cref="RecievePayment"/> class.
        /// </summary>
        public RecievePayment()
        {
           
        }
        /// <summary>
        /// Gets or sets a value indicating whether [fees on customer].
        /// </summary>
        /// <value><c>true</c> if [fees on customer]; otherwise, <c>false</c>.</value>
        [JsonProperty("FeesOnCustomer")] public bool FeesOnCustomer { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        [JsonProperty("CustomerName")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer msisdn.
        /// </summary>
        /// <value>The customer msisdn.</value>
        [JsonProperty("CustomerMsisdn")]
        public string CustomerMsisdn { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>The customer email.</value>
        [JsonProperty("CustomerEmail")]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        /// <value>The channel.</value>
        [JsonProperty("Channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the primary callback URL.
        /// </summary>
        /// <value>The primary callback URL.</value>
        [JsonProperty("PrimaryCallbackUrl")]
        public string PrimaryCallbackUrl { get; set; }

        /// <summary>
        /// Gets or sets the secondary callback URL.
        /// </summary>
        /// <value>The secondary callback URL.</value>
        [JsonProperty("SecondaryCallbackUrl")]
        public string SecondaryCallbackUrl { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the client reference.
        /// </summary>
        /// <value>The client reference.</value>
        [JsonProperty("ClientReference")]
        public string ClientReference { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonProperty("Token")]
        public string Token { get; set; }
    }
}