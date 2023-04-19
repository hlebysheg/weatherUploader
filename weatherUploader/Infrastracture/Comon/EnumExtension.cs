using System.ComponentModel;
using System.Reflection;

namespace System
{
    public static class EnumExtension
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            MemberInfo[] memInfo = enumVal
                .GetType()
                .GetMember(enumVal.ToString());

            object[] attributes = memInfo[0].GetCustomAttributes(typeof(T), false);

            return attributes.Any()
                ? (T)attributes[0]
                : null;
        }

        public static string GetDescription(this Enum enumVal)
        {
            return enumVal
                ?.GetAttributeOfType<DescriptionAttribute>()
                ?.Description;
        }
    }
}
