namespace weatherUploader.Models.Entity
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TimeMSC { get; set; }
        public double T { get; set; }
        public double Humidity { get; set; }
        public double Td { get; set; }
        public double Pressure { get; set; }
        public string? WindDirection { get; set; } // todo вынести в отельное поле БД и изначально заполнить
        public double? WindSpeed { get; set; }
        public double? Сloudiness { get; set; }
        public double? H { get; set; }
        public double? VV { get; set; }
        public string? WeatherConditions { get; set; }//todo вынести в Enum

        //ссылка на исходный файл
        public WeatherFileInfo? FileInfo { get; set; }
    }
}
