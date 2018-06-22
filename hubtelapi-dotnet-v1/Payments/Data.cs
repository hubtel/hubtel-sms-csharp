
// ***********************************************************************
// <copyright file="Data.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class Data.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Gets or sets the amount after charges.
        /// </summary>
        /// <value>The amount after charges.</value>
        public decimal AmountAfterCharges { get; set; }
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>The transaction identifier.</value>
        public string TransactionId { get; set; }
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
        /// <summary>
        /// Gets or sets the external transaction identifier.
        /// </summary>
        /// <value>The external transaction identifier.</value>
        public string ExternalTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the charges.
        /// </summary>
        /// <value>The charges.</value>
        public decimal Charges { get; set; }

    }
}