using System;

namespace VddsMediaNet.Converters
{
    public class IntConverter : IVddsMediaConverter
    {
        public string Convert(object value)
        {
            if (value is int)
            {
                var number = (int)value;
                return number.ToString();
            }

            return null;
        }

        public object ConvertBack(string value, Type type = null)
        {
            if (string.IsNullOrEmpty(value)) return null;

            try
            {
                return int.Parse(value);
            }
            catch
            {
                return null;
            }
        }
    }
}