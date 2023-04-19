using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using weatherUploader.Infrastracture.Comon.Enum;
using weatherUploader.Infrastracture.Service.FileService;
using weatherUploader.Infrastracture.Service.WeatherParser;
using weatherUploader.Models;
using weatherUploader.Models.DTO;

namespace weatherUploader.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherParser _parser;

        public WeatherController(ILogger<WeatherController> logger, IWeatherParser parser)
        {
            _logger = logger;
            _parser = parser;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult Preview()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] WeatherDTO WeatherFiles)
        {
            var response = await _parser.ParseExelFileAsync(WeatherFiles);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}