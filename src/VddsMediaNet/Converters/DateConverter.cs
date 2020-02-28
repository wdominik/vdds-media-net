using System;
using System.Globalization;

namespace VddsMediaNet.Converters
{
    public class DateConverter : IVddsMediaConverter
    {
        public string Convert(object value)
        {
            if (value is DateTime)
            {
                var date = (DateTime)value;
                return date.ToString("yyyyMMdd");
            }

            return null;
        }

        public object ConvertBack(string value, Type type = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return DateTime.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture);
        }
    }
}