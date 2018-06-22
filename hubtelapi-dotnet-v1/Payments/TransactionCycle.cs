// ***********************************************************************
// <copyright file="TransactionCycle.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class TransactionCycle.
    /// </summary>
    public partial class TransactionCycle
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("Status")]
        public string Status { get; set; }
    }
}