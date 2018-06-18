using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Payments
{
    public  class Store
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("postal_address")]
        public string PostalAddress { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }
    }
}