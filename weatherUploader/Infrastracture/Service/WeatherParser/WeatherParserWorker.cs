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
using weatherUploader.Models.DTO;

namespace weatherUploader.Infrastracture.Service.WeatherParser
{
    public class WeatherParserWorker : IWeatherParser
    {
        private readonly IFileService _fsv;

        public WeatherParserWorker(IFileService fsv)
        {
            _fsv = fsv;
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
                XSSFWorkbook hssfwb;
                using (FileStream stream = new FileStream(Path.Combine(weatherFile.Path), FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new XSSFWorkbook(stream);
                }

                if (!IsValidConstruction(hssfwb))
                {
                    return ParseStatusEnum.WrongExelStructure;
                }
                //старт парсинга
                for (int i = 0; i < 12; i++)
                {
                    //проверка на наличие основных параметров в таблице
                    var sheet = hssfwb.GetSheetAt(i);
                    var date = sheet.GetRow(4).ToList();//start from 4 row and end where data = ""
                }
            }
            return ParseStatusEnum.Succes;
        }

        private bool IsValidConstruction(XSSFWorkbook hssfwb)
        {
            if (hssfwb.NumberOfSheets != 12) 
            {
                return false;
            }

            for (int i = 0; i < 12; i++)
            {
                //проверка на наличие основных параметров в таблице
                var sheet = hssfwb.GetSheetAt(i);
                bool correctDate = GetCell(sheet, "A3").StringCellValue == "Дата";
                bool correctTime = GetCell(sheet, "B3").StringCellValue == "Время";
                bool correctTemp = GetCell(sheet, "C3").StringCellValue == "Т";

                if(!correctDate || !correctTime || !correctTemp)
                {
                    return false;
                }
            }

            return true;
        }

        private ICell GetCell(ISheet sheet, string adr)
        {
            var cr = new CellReference(adr);
            var row = sheet.GetRow(cr.Row);
            return row.GetCell(cr.Col);
        }
    }
}
