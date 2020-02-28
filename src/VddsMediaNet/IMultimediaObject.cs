using System;

namespace VddsMediaNet
{
    public interface IMultimediaObject
    {
        string MultimediaObjectId { get; set; }

        string OfficeId { get; set; }

        MultimediaObjectType Type { get; set; }

        MultimediaObjectTypeId TypeId { get; set; }

        string Teeth { get; set; }

        bool? Pregnancy { get; set; }

        string XrayComment { get; set; }

        string XrayExposure { get; set; }

        string XrayCurrent { get; set; }

        string XrayVoltage { get; set; }

        MultimediaObjectExtension Extension { get; set; }

        MultimediaObjectColorType ColorType { get; set; }

        DateTime? Date { get; set; }

        string Time { get; set; }

        string Comment { get; set; }
    }
}