using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using weatherUploader.Models.Entity;

namespace weatherUploader.Infrastracture.Service.ValidateFileService
{
    public class ValidateFileWorker : IVilidateFileService
    {
        public XSSFWorkbook? ValidateFile(WeatherFileInfo info)
        {
            XSSFWorkbook hssfwb;
            using (FileStream stream = new FileStream(Path.Combine(info.Path), FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(stream);
                //add md5 hash check
            }
            if (hssfwb.NumberOfSheets != 12)
            {
                return null;
            }

            for (int i = 0; i < 12; i++)
            {
                //проверка на наличие основных параметров в таблице
                var sheet = hssfwb.GetSheetAt(i);
                var cells = sheet.GetRow(2).Cells;

                bool correctDate = cells[0].StringCellValue == "Дата";
                bool correctTime = cells[1].StringCellValue == "Время";
                bool correctTemp = cells[2].StringCellValue == "Т";
				bool correctPercent = cells[3].StringCellValue == "Отн. влажность";

				if (!correctDate || !correctTime || !correctTemp || !correctPercent)
                {
                    return null;
                }
            }

            return hssfwb;
        }
    }
}
