using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OAuth2._0.Configurations;
using OAuth2._0.Models;
using OAuth2._0.Repositories;
using OAuth2._0.Services;

namespace OAuth2._0.Controllers
{
    public class AzureController : Controller
    {
        private readonly ILogger<AzureController> _logger;
        private readonly IClientService _clientService;
        private readonly AzureB2CConfig _azureB2CConfig;
        private readonly ITokenRepository _tokenRepository;

        public AzureController(ILogger<AzureController> logger, IClientService clientService, IOptionsMonitor<AzureB2CConfig> azureB2CConfig, ITokenRepository tokenRepository)
        {
            _logger = logger;
            _clientService = clientService;
            _tokenRepository = tokenRepository;
            _azureB2CConfig = azureB2CConfig.CurrentValue;
        }

        public async Task<IActionResult> Oauth([FromQuery]string code)
        {
            try
            {
                var d = new AzureTokenPayloadModel()
                {
                    GrantType = "authorization_code",
                    Scope = _azureB2CConfig.scope,
                    ClientId = _azureB2CConfig.ClientId,
                    RedirectUri = _azureB2CConfig.RedirectUri,
                    Code = code,
                    ClientSecret = _azureB2CConfig.Secret
                };

                var response = await _clientService.PostWithFormUrlEncodedAsync(_azureB2CConfig.TokenUrl, d);
                if (response.ErrorFlag)
                    throw new Exception(response.Msg);

                var token = JsonConvert.DeserializeObject<AzureTokenModel>(response.Data);
                if (token == null)
                    throw new ArgumentException("Missing token data");

                _tokenRepository.InsertToken(token);

                return RedirectToAction("Tokens");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, exception);
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Tokens()
        {
            var tokens = _tokenRepository.GetTokens();
            return View(tokens);
        }
    }
}
