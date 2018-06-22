// ***********************************************************************
// <copyright file="Actions.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class Actions.
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// Gets or sets the cancel URL.
        /// </summary>
        /// <value>The cancel URL.</value>
        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }

        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>The return URL.</value>
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
    }
}