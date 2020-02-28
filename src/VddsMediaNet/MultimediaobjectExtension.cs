using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum MultimediaObjectExtension
    {
        Undefined,

        [VddsMediaEnum("JPG")]
        Jpeg,

        [VddsMediaEnum("PDF")]
        Pdf,

        [VddsMediaEnum("PNG")]
        Png,

        [VddsMediaEnum("TIF")]
        Tiff
    }
}