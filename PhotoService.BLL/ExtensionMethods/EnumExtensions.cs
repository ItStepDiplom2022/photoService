using System.ComponentModel;

namespace PhotoService.BLL.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            return ((DescriptionAttribute)Attribute.GetCustomAttribute(enumValue.GetType().GetField(enumValue.ToString()), typeof(DescriptionAttribute))).Description;
        }
    }
}
