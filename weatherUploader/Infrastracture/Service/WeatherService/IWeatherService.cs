using weatherUploader.Infrastracture.Common.Data;
using weatherUploader.Models.DTO;

namespace weatherUploader.Infrastracture.Service.WeatherService
{
	public interface IWeatherService
	{
		public Task<TableDTO> GetWeatherByFilter(WeatherFilter filter);
	}
}
