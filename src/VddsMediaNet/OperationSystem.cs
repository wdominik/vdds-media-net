using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum OperationSystem
    {
        Undefined,

        [VddsMediaEnum("2")]
        Dos,

        [VddsMediaEnum("3")]
        Unix,

        [VddsMediaEnum("1")]
        Windows
    }
}