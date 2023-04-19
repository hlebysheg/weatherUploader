using System.Web;
namespace weatherUploader.Models.DTO
{
    public class WeatherDTO
    {
        public IFormFileCollection WeatherFiles { set; get; }
    }
}
