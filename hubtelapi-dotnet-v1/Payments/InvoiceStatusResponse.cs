// ***********************************************************************
// <copyright file="InvoiceStatusResponse.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class InvoiceStatusResponse.
    /// </summary>
    public class InvoiceStatusResponse
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
        /// Gets or sets the created invoice.
        /// </summary>
        /// <value>The created invoice.</value>
        [JsonProperty("createdInvoice")]
        public CreatedInvoice CreatedInvoice { get; set; }

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
    }
}