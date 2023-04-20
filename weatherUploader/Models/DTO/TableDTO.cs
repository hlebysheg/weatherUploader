using weatherUploader.Models.Entity;

namespace weatherUploader.Models.DTO
{
	public class TableDTO
	{
		public List<WeatherForecast> WeatherForecast { get; set; }
		public int PageTotal { get; set; }
		public int PageNumber { get; set; }
	}
}
