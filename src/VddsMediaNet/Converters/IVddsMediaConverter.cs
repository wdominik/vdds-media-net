using System;

namespace VddsMediaNet.Converters
{
    public interface IVddsMediaConverter
    {
        string Convert(object value);

        object ConvertBack(string value, Type type = null);
    }
}