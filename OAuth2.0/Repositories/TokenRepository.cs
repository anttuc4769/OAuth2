using OAuth2._0.Models;
using OAuth2._0.Repositories.Models;

namespace OAuth2._0.Repositories
{
    public interface ITokenRepository
    {
        List<Token> GetTokens();
        void InsertToken(AzureTokenModel token);
    }

    public class TokenRepository : ITokenRepository
    {
        private readonly oauth2Context _dbContext;

        public TokenRepository(oauth2Context dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Token> GetTokens()
        {
            var tokens = _dbContext.Tokens.ToList();
            return tokens;
        }

        public void InsertToken(AzureTokenModel token)
        {
            var newRecord = new Token()
            {
                Source = "Azure AD B2C",
                Scope = token.Scope.ToString(), 
                ExpiresIn = token.ExpiresIn,
                ExpiresOn = token.ExpiresOn,
                RefreshTokenExpiresIn = token.RefreshTokenExpiresIn,
                Resource = token.Resource.ToString(),
                ProfileInfo = token.ProfileInfo,
                TokenType = token.TokenType,
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken,
                Created = DateTimeOffset.Now,
                Active = true
            };

            _dbContext.Tokens.Add(newRecord);
            _dbContext.SaveChanges();
        }
    }
}
