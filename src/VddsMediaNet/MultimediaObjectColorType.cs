using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum MultimediaObjectColorType
    {
        Undefined,

        [VddsMediaEnum("COLOR")]
        Color,

        [VddsMediaEnum("GRAYSCALE")]
        Grayscale,

        [VddsMediaEnum("LINEART")]
        Text,

        [VddsMediaEnum("3D")]
        ThreeDimensional
    }
}