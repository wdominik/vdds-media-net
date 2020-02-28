using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum Sex
    {
        Undefined,

        [VddsMediaEnum("W")]
        Female,

        [VddsMediaEnum("M")]
        Male
    }
}