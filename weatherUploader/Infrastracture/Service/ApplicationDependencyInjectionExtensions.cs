using weatherUploader.Infrastracture.Service.FileService;
using weatherUploader.Infrastracture.Service.WeatherParser;

namespace weatherUploader.Infrastracture.Service
{
    public static class ApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            return services
                .AddScoped<IFileService, FileServiceWorker>()
                .AddScoped<IWeatherParser, WeatherParserWorker>();
        }
    }
}
