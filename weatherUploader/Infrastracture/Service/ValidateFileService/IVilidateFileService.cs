using NPOI.XSSF.UserModel;
using weatherUploader.Models.DTO;
using weatherUploader.Models.Entity;

namespace weatherUploader.Infrastracture.Service.ValidateFileService
{
    public interface IVilidateFileService
    {
        public XSSFWorkbook? ValidateFile(WeatherFileInfo info);
    }
}
