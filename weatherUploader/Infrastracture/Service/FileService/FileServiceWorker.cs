using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection;
using System.Security.Cryptography;
using weatherUploader.Models.Entity;

namespace weatherUploader.Infrastracture.Service.FileService
{
    public class FileServiceWorker : IFileService
    {
        private readonly IConfiguration _conf;
        private readonly ILogger<FileServiceWorker> _logger;
        private readonly WeatherDbContext _ctx;
        public FileServiceWorker(IConfiguration conf, ILogger<FileServiceWorker> log, WeatherDbContext ctx)
        {
            _conf = conf;
            _logger = log;
            _ctx = ctx;
        }
        public bool delete(string path)
        {
            if (File.Exists(Path.Combine(path)))
            { 
                File.Delete(Path.Combine(path));
                _logger.LogWarning("Delete file in path: " + path);
                return true;
            }
            return false;
        }

        public async Task<WeatherFileInfo> saveFile(IFormFile file)
        {
            if (file.Length == 0 || System.IO.Path.GetExtension(file.FileName) != ".xlsx")
            {
                return null;
            }

            var filePath = Path.Combine(_conf["FileOptions:UploadPath"] ?? "/",
                Guid.NewGuid().ToString() + file.FileName);

            string hash;

            using (var md5 = MD5.Create())
            {
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                    hash = string.Concat(md5.ComputeHash(stream).Select(x => x.ToString("X2")));
                }
            }

            WeatherFileInfo result = new WeatherFileInfo
            {
                Name = file.FileName,
                Path = filePath,
                hash = hash,
            };

            try
            {
                await _ctx.WeatherFileInfo.AddAsync(result);
                //await _ctx.SaveChangesAsync(); сохранение в парсере
            }
            catch
            {
                return null;
            }
            return result;

        }
    }
}
