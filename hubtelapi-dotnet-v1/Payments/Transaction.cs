// ***********************************************************************
// <copyright file="Transaction.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class Transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the invoice token.
        /// </summary>
        /// <value>The invoice token.</value>
        public string InvoiceToken { get; set; }
        /// <summary>
        /// Gets or sets the network transaction identifier.
        /// </summary>
        /// <value>The network transaction identifier.</value>
        public string NetworkTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the hubtel transaction identifier.
        /// </summary>
        /// <value>The hubtel transaction identifier.</value>
        public string HubtelTransactionId { get; set; } 
    }
}