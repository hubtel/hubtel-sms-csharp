
// ***********************************************************************
// <copyright file="Datum.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class Datum.
    /// </summary>
    public class Datum
    {
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the transaction status.
        /// </summary>
        /// <value>The transaction status.</value>
        [JsonProperty("TransactionStatus")]
        public string TransactionStatus { get; set; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>The transaction identifier.</value>
        [JsonProperty("TransactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the network transaction identifier.
        /// </summary>
        /// <value>The network transaction identifier.</value>
        [JsonProperty("NetworkTransactionId")]
        public string NetworkTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the invoice token.
        /// </summary>
        /// <value>The invoice token.</value>
        [JsonProperty("InvoiceToken")]
        public string InvoiceToken { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>The type of the transaction.</value>
        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>The payment method.</value>
        [JsonProperty("PaymentMethod")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the client reference.
        /// </summary>
        /// <value>The client reference.</value>
        [JsonProperty("ClientReference")]
        public string ClientReference { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>The country code.</value>
        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        /// <value>The transaction amount.</value>
        [JsonProperty("TransactionAmount")]
        public double TransactionAmount { get; set; }

        /// <summary>
        /// Gets or sets the fee.
        /// </summary>
        /// <value>The fee.</value>
        [JsonProperty("Fee")]
        public double? Fee { get; set; }

        /// <summary>
        /// Gets or sets the amount after fees.
        /// </summary>
        /// <value>The amount after fees.</value>
        [JsonProperty("AmountAfterFees")]
        public double AmountAfterFees { get; set; }

        /// <summary>
        /// Gets or sets the name of the card scheme.
        /// </summary>
        /// <value>The name of the card scheme.</value>
        [JsonProperty("CardSchemeName")]
        public object CardSchemeName { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>The card number.</value>
        [JsonProperty("CardNumber")]
        public object CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>The mobile number.</value>
        [JsonProperty("MobileNumber")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the mobile channel.
        /// </summary>
        /// <value>The name of the mobile channel.</value>
        [JsonProperty("MobileChannelName")]
        public string MobileChannelName { get; set; }

        /// <summary>
        /// Gets or sets the transaction cycle.
        /// </summary>
        /// <value>The transaction cycle.</value>
        [JsonProperty("TransactionCycle")]
        public TransactionCycle[] TransactionCycle { get; set; }

        /// <summary>
        /// Gets or sets the related transaction identifier.
        /// </summary>
        /// <value>The related transaction identifier.</value>
        [JsonProperty("RelatedTransactionId")]
        public object RelatedTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the type of the related transaction.
        /// </summary>
        /// <value>The type of the related transaction.</value>
        [JsonProperty("RelatedTransactionType")]
        public object RelatedTransactionType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Datum"/> is disputed.
        /// </summary>
        /// <value><c>true</c> if disputed; otherwise, <c>false</c>.</value>
        [JsonProperty("Disputed")]
        public bool Disputed { get; set; }

        /// <summary>
        /// Gets or sets the disputed amount.
        /// </summary>
        /// <value>The disputed amount.</value>
        [JsonProperty("DisputedAmount")]
        public long DisputedAmount { get; set; }

        /// <summary>
        /// Gets or sets the disputed amount fee.
        /// </summary>
        /// <value>The disputed amount fee.</value>
        [JsonProperty("DisputedAmountFee")]
        public long DisputedAmountFee { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded.
        /// </summary>
        /// <value>The total amount refunded.</value>
        [JsonProperty("TotalAmountRefunded")]
        public long TotalAmountRefunded { get; set; }
    }
}