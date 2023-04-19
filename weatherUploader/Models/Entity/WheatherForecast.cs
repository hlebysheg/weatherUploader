namespace weatherUploader.Models.Entity
{
    public class WheatherForecast
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
        public int? Сloudiness { get; set; }
        public int? H { get; set; }
        public int? VV { get; set; }
        public string? WeatherConditions { get; set; }//todo вынести в Enum

        //ссылка на исходный файл
        public WeatherFileInfo FileInfo { get; set; }
    }
}
