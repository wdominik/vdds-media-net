using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum Salutation
    {
        Undefined,

        [VddsMediaEnum("3")]
        Miss,

        [VddsMediaEnum("1")]
        Mr,

        [VddsMediaEnum("2")]
        Mrs
    }
}