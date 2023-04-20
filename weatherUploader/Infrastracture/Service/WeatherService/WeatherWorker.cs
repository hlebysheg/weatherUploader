using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;
using weatherUploader.Infrastracture.Common.Data;
using weatherUploader.Models.DTO;
using weatherUploader.Models.Entity;

namespace weatherUploader.Infrastracture.Service.WeatherService
{
	public class WeatherWorker : IWeatherService
	{
		private readonly WeatherDbContext _db ;
		public WeatherWorker(WeatherDbContext db)
		{
			_db = db;
		}
		public async Task<TableDTO> GetWeatherByFilter(WeatherFilter filter)
		{
			var source = _db.WheatherForecast;
			var weather = await source
									.Skip(filter.Page * filter.PageSize)
									.Take(filter.PageSize)
									.ToListAsync();
			var count = await source.CountAsync() / filter.PageSize;
			TableDTO response = new TableDTO
			{
				WeatherForecast = weather,
				PageTotal = count,
				PageNumber = filter.Page
			};
			return response;
		}
	}
}
