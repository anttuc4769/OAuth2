namespace OAuth2._0.Configurations
{
    public class AzureB2CConfig
    {
        public string Url => $"https://{Instance}.b2clogin.com/{Instance}.onmicrosoft.com/{Policy}/oauth2/v2.0/authorize?" +
                             $"client_id={ClientId}&" +
                             $"response_type={ResponseType}&" +
                             $"redirect_uri={RedirectUri}&" +
                             $"response_mode={ResponseMode}&" +
                             $"scope={scope}";
        public string TokenUrl => $"https://{Instance}.b2clogin.com/{Instance}.onmicrosoft.com/{Policy}/oauth2/v2.0/token";
        public string Instance { get; set; }
        public string Policy { get; set; }
        public string ClientId { get; set; }
        public string ResponseType { get; set; }
        public string RedirectUri { get; set; }
        public string ResponseMode { get; set; }
        public string scope { get; set; }
        public string Secret { get; set; }
        public string ApiKey { get; set; }
    }
}
