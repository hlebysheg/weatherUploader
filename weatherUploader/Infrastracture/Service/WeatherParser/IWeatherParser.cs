using weatherUploader.Infrastracture.Comon.Enum;
using weatherUploader.Models.DTO;

namespace weatherUploader.Infrastracture.Service.WeatherParser
{
    public interface IWeatherParser
    {
        Task<ParseStatusEnum> ParseExelFileAsync(WeatherDTO dto);
    }
}
