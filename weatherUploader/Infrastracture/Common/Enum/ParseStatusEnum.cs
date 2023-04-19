using System.ComponentModel;

namespace weatherUploader.Infrastracture.Comon.Enum
{
    public enum ParseStatusEnum : sbyte
    {
        [Description("Завершено")]
        Succes,

        [Description("Неверный формат файла")]
        WrongFormat,

        [Description("Неверная структура файла")]
        WrongExelStructure,

        [Description("Неверный формат даты в файле")]
        DateFormatError,
    }
}
