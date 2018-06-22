// ***********************************************************************
// <copyright file="TransactionResponse.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class TransactionResponse.
    /// </summary>
    public class TransactionResponse
    {
        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>The response code.</value>
        [JsonProperty("ResponseCode")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("Data")]
        public List<Datum> Data { get; set; }

        
    }
}