using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using weatherUploader.Infrastracture.Common.Data;
using weatherUploader.Infrastracture.Comon.Enum;
using weatherUploader.Infrastracture.Service.FileService;
using weatherUploader.Infrastracture.Service.WeatherParser;
using weatherUploader.Infrastracture.Service.WeatherService;
using weatherUploader.Models;
using weatherUploader.Models.DTO;

namespace weatherUploader.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherParser _parser;
        private readonly IWeatherService _weatherService;


		public WeatherController(ILogger<WeatherController> logger, IWeatherParser parser , IWeatherService weatherService)
        {
            _logger = logger;
            _parser = parser;
            _weatherService = weatherService;

		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        public async Task<IActionResult> PreviewAsync(int? year, int? mounth, int? pageSize, int? page)
        {
            var table = await _weatherService.GetWeatherByFilter(new WeatherFilter(year, mounth, pageSize, page));

			return View(table);
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