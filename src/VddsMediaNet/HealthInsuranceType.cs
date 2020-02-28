using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum HealthInsuranceType
    {
        Undefined,

        [VddsMediaEnum("F")]
        Family,

        [VddsMediaEnum("M")]
        Member,

        [VddsMediaEnum("P")]
        PrivatelyInsured,

        [VddsMediaEnum("R")]
        Retired
    }
}