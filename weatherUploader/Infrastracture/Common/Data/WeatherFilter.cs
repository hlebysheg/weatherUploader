namespace weatherUploader.Infrastracture.Common.Data
{
	public class WeatherFilter
	{
		public int? Year { get; private set; }

		public int? Mounth { get; private set; }

		public int Page { get; private set; }

		public int PageSize { get; private set; }

		public WeatherFilter(int? year, int? mounth, int? pageSize, int? page)
		{
			Year = year;
			Mounth = mounth > 12 || mounth == 0 ? null: mounth;
			Page = page ?? 0;
			PageSize = pageSize ?? 30;
		}
	}
}
