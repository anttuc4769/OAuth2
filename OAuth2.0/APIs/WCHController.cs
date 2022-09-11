using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OAuth2._0.Configurations;
using OAuth2._0.Services;

namespace OAuth2._0.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class WCHController : ControllerBase
    {
        private readonly ILogger<WCHController> _logger;
        private readonly IClientService _clientService;
        private readonly AzureB2CConfig _azureB2CConfig;

        public WCHController(ILogger<WCHController> logger, IClientService clientService, IOptionsMonitor<AzureB2CConfig> azureB2CConfig)
        {
            _logger = logger;
            _clientService = clientService;
            _azureB2CConfig = azureB2CConfig.CurrentValue;
        }

        [HttpGet]
        [Route("Test")]
        public async Task<string> Test([FromQuery] string token)
        {
            try
            {
                _clientService.HttpClient.DefaultRequestHeaders.Add("ocp-apim-subscription-key", _azureB2CConfig.ApiKey);
                var response = await _clientService.GetAsync("https://wch-api.azure-api.net/api/test", token);
                return JsonConvert.SerializeObject(response);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, exception);
                return JsonConvert.SerializeObject(exception);
            }
        }
    }
}
