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
                bool correctDate = GetCell(sheet, "A3").StringCellValue == "Дата";
                bool correctTime = GetCell(sheet, "B3").StringCellValue == "Время";
                bool correctTemp = GetCell(sheet, "C3").StringCellValue == "Т";

                if (!correctDate || !correctTime || !correctTemp)
                {
                    return null;
                }
            }

            return hssfwb;
        }

        private ICell GetCell(ISheet sheet, string adr)
        {
            var cr = new CellReference(adr);
            var row = sheet.GetRow(cr.Row);
            return row.GetCell(cr.Col);
        }
    }
}
