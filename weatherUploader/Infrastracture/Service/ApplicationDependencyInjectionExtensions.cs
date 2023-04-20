using weatherUploader.Infrastracture.Service.FileService;
using weatherUploader.Infrastracture.Service.ValidateFileService;
using weatherUploader.Infrastracture.Service.WeatherParser;
using weatherUploader.Infrastracture.Service.WeatherService;

namespace weatherUploader.Infrastracture.Service
{
    public static class ApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            return services
                .AddScoped<IFileService, FileServiceWorker>()
                .AddScoped<IWeatherParser, WeatherParserWorker>()
                .AddScoped<IWeatherService, WeatherWorker>()
                .AddScoped<IVilidateFileService, ValidateFileWorker>();
        }
    }
}
