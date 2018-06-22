// ***********************************************************************
// <copyright file="InvoiceResponse.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class InvoiceResponse.
    /// </summary>
    public class InvoiceResponse
    {
        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>The response code.</value>
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the response text.
        /// </summary>
        /// <value>The response text.</value>
        [JsonProperty("response_text")]
        public string ResponseText { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>The invoice.</value>
        [JsonProperty("invoice")]
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        [JsonProperty("actions")]
        public Actions Actions { get; set; }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        /// <value>The custom data.</value>
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        /// <value>The mode.</value>
        [JsonProperty("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the receipt URL.
        /// </summary>
        /// <value>The receipt URL.</value>
        [JsonProperty("receipt_url")]
        public string ReceiptUrl { get; set; }
    }
}