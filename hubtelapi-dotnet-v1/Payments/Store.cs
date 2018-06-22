
// ***********************************************************************
// <copyright file="Store.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class Store.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tagline.
        /// </summary>
        /// <value>The tagline.</value>
        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        /// <summary>
        /// Gets or sets the postal address.
        /// </summary>
        /// <value>The postal address.</value>
        [JsonProperty("postal_address")]
        public string PostalAddress { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the logo URL.
        /// </summary>
        /// <value>The logo URL.</value>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the website URL.
        /// </summary>
        /// <value>The website URL.</value>
        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }
    }
}