using System;

namespace VddsMediaNet.Converters
{
    public class StringConverter : IVddsMediaConverter
    {
        public string Convert(object value)
        {
            if (value is string)
            {
                return (string)value;
            }

            return null;
        }

        public object ConvertBack(string value, Type type = null)
        {
            return value;
        }
    }
}