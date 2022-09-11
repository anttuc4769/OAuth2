using Newtonsoft.Json;

namespace OAuth2._0.Models
{
    public class AzureTokenPayloadModel
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }

}
