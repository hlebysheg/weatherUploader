using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.IO;
using weatherUploader.Infrastracture.Comon.Enum;
using weatherUploader.Infrastracture.Service.FileService;
using weatherUploader.Infrastracture.Service.ValidateFileService;
using weatherUploader.Models.DTO;
using weatherUploader.Models.Entity;

namespace weatherUploader.Infrastracture.Service.WeatherParser
{
    public class WeatherParserWorker : IWeatherParser
    {
        private readonly IFileService _fsv;

        private readonly WeatherDbContext _db;

        private readonly IVilidateFileService _vld;

        public WeatherParserWorker(IFileService fsv, WeatherDbContext db, IVilidateFileService validator)
        {
            _fsv = fsv;
            _db = db;
            _vld = validator;
        }
        public async Task<ParseStatusEnum> ParseExelFileAsync(WeatherDTO dto)
        {
            foreach(var file in dto.WeatherFiles)
            {
                var weatherFile = await _fsv.saveFile(file);
                if (weatherFile == null)
                {
                    return ParseStatusEnum.WrongFormat;
                }
                XSSFWorkbook? hssfwb = _vld.ValidateFile(weatherFile);//проверка структуры(включает проверку кол-во страниц = 12)

                if(hssfwb == null)
                {
                    _fsv.delete(weatherFile.Path);//Удаляет неверный файл
                    return ParseStatusEnum.WrongExelStructure;
                }

                List<WeatherForecast> weathers = new List<WeatherForecast>();

                for (int i = 0; i < 12; i++)
                {
                    //проверка на наличие основных параметров в таблице
                    for(int j = 4; ; j++)
                    {
                        var sheet = hssfwb.GetSheetAt(i);
                        var row = sheet.GetRow(j)?.ToArray();
                        if(row == null)
                        {
                            break;
                        }

                        DateTime dt;
                        bool isCorrectDate = DateTime.TryParse(row[0].ToString()+ " " + row[1].ToString(), out dt);
                        if (!isCorrectDate)
                        {
                            return ParseStatusEnum.DateFormatError;
                        }

                        try
                        {
                            weathers.Add(WeatherForecastFromArray(row, weatherFile));
                        }
                        catch (Exception ex)
                        {
                            return ParseStatusEnum.WrongExelStructure;
                        }
                    }
                    //start from 4 row and end where data = ""
                }
                await _db.WheatherForecast.AddRangeAsync(weathers);//weathers
            }
            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                return ParseStatusEnum.SaveChangeError;
            }
            return ParseStatusEnum.Succes;
        }

        private WeatherForecast WeatherForecastFromArray(ICell[] row, WeatherFileInfo? info)
        {
            var length = row.Count();

            return new WeatherForecast
            {
                Date = DateTime.Parse(row[0].ToString()).Date,
                TimeMSC = row[1].ToString(),
                T = row[2].NumericCellValue,
                Humidity = row[3].NumericCellValue,
                Td = row[4].NumericCellValue,
                Pressure = row[5].NumericCellValue,
                WindDirection = row[6].StringCellValue,
                WindSpeed = row[7].CellType == NPOI.SS.UserModel.CellType.Numeric ? row[7].NumericCellValue : null,
                Сloudiness = row[8].CellType == NPOI.SS.UserModel.CellType.Numeric ? row[8].NumericCellValue : null,
                H = row[9].CellType == NPOI.SS.UserModel.CellType.Numeric ? row[9].NumericCellValue : null,
                VV = row[10].CellType == NPOI.SS.UserModel.CellType.Numeric ? row[10].NumericCellValue : null,
                WeatherConditions = length > 11 ? row[11].StringCellValue : null,
                FileInfo = info,
            };
        }
    }
}
