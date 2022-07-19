using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Exceptions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            return ((DescriptionAttribute)Attribute.GetCustomAttribute((enumValue.GetType().GetField(enumValue.ToString())), typeof(DescriptionAttribute))).Description;
        }
    }
}
