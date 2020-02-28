using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum MultimediaObjectTypeId
    {
        Undefined,

        [VddsMediaEnum("0")]
        Delete,

        [VddsMediaEnum("23")]
        Other,

        [VddsMediaEnum("7")]
        Photo,

        // Proprietary for Dampsoft DS-Win
        [VddsMediaEnum("38")]
        ProfilePhoto,

        [VddsMediaEnum("24")]
        Unknown
    }
}