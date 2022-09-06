namespace KantineAPIv2.Identity
{
    public class IdentityServerConfig
    {
        private readonly IConfiguration _configuration;

        public IdentityServerConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Client> GetClient()
        {
            Client client = new Client()
            {
                ClientId = "api",
                ClientSecrets = { new Secret(_configuration["IdentityServer:Secret"].Sha256()) },
                AllowedGrantTypes = new List<string> { "password", "client_credentials", "refresh_token" },
                AllowedScopes = { IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                UpdateAccessTokenClaimsOnRefresh = true,
                RefreshTokenExpiration = TokenExpiration.Absolute,
                RefreshTokenUsage = TokenUsage.ReUse,
                AbsoluteRefreshTokenLifetime = int.MaxValue,
                AllowOfflineAccess = true
            };

            return new List<Client>() { client };
        }

        public List<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("Custom", "Custom")
            };
        }

        public List<ApiResource> GetApiResources()
        {
            ApiResource apiResource = new ApiResource();
            apiResource.Name = "api";
            apiResource.Enabled = true;
            apiResource.DisplayName = "Api";
            apiResource.Scopes = new List<string>
            {
                "api",
                IdentityServerConstants.StandardScopes.OfflineAccess
            };

            return new List<ApiResource> { apiResource };
        }

        public List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
