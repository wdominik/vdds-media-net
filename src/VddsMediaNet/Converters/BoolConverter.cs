using System;

namespace VddsMediaNet.Converters
{
    public class BoolConverter : IVddsMediaConverter
    {
        public string Convert(object value)
        {
            if (value is bool)
            {
                return (bool)value ? "1" : "0";
            }

            return "0";
        }

        public object ConvertBack(string value, Type type = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return value == "1";
        }
    }
}