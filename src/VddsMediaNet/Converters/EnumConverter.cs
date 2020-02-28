using System;
using System.Linq;
using System.Reflection;
using VddsMediaNet.Attributes;

namespace VddsMediaNet.Converters
{
    public class EnumConverter : IVddsMediaConverter
    {
        public string Convert(object value)
        {
            if (value is Enum)
            {
                var attribute = value.GetType().GetField(value.ToString()).GetCustomAttribute(typeof(VddsMediaEnumAttribute)) as VddsMediaEnumAttribute;

                if (attribute == null)
                {
                    return null;
                }

                return attribute.Value;
            }

            return null;
        }

        public object ConvertBack(string value, Type type = null)
        {
            if (type == null)
            {
                return null;
            }

            foreach (var field in type.GetFields())
            {

                var attribute = (VddsMediaEnumAttribute)field.GetCustomAttribute(typeof(VddsMediaEnumAttribute), false);

                if (attribute == null)
                {
                    continue;
                }

                if (attribute.Value == value)
                {
                    return field.GetValue(null);
                }
            }

            return null;
        }
    }
}