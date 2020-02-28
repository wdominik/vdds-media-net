using System;

namespace VddsMediaNet.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class VddsMediaEnumAttribute : Attribute
    {
        public string Value { get; set; }


        public VddsMediaEnumAttribute(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}