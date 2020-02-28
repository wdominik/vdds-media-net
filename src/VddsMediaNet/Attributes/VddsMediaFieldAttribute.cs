using System;

namespace VddsMediaNet.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VddsMediaFieldAttribute : Attribute
    {
        public string Name { get; set; }

        public string Section { get; set; }


        public VddsMediaFieldAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}