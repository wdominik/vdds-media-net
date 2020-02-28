using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum MultimediaObjectType
    {
        Undefined,

        [VddsMediaEnum("Delete")]
        Delete,

        [VddsMediaEnum("Other")]
        Other,

        [VddsMediaEnum("Photo")]
        Photo,

        // Proprietary for Dampsoft DS-Win
        [VddsMediaEnum("Patient")]
        ProfilePhoto,

        [VddsMediaEnum("Unknown")]
        Unknown,
    }
}