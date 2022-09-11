using Microsoft.AspNetCore.Mvc;
using OAuth2._0.Models;
using System.Diagnostics;
using OAuth2._0.Configurations;
using Microsoft.Extensions.Options;

namespace OAuth2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AzureB2CConfig _azureB2CConfig;

        public HomeController(ILogger<HomeController> logger, IOptionsMonitor<AzureB2CConfig> azureB2CConfig)
        {
            _logger = logger;
            _azureB2CConfig = azureB2CConfig.CurrentValue;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel() { AzureB2CUrl = _azureB2CConfig.Url };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class HomeViewModel
    {
        public string AzureB2CUrl { get; set; }
    }
}