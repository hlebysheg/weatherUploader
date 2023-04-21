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
			bool isYear = filter.Year != null;
			bool isMounth = filter.Mounth != null;
			//todo add specification pattern
			var source = _db.WheatherForecast.Where(el =>
														(isYear? el.Date.Year == filter.Year: true )
														&& (isMounth? el.Date.Month == filter.Mounth: true));

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
