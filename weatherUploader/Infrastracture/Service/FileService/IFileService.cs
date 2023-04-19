using weatherUploader.Models.Entity;

namespace weatherUploader.Infrastracture.Service.FileService
{
    public interface IFileService
    {
        public Task<WeatherFileInfo> saveFile(IFormFile file);
        public bool delete(string path);
    }
}
