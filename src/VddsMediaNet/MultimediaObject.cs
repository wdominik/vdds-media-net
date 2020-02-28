using System;
using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public class MultimediaObject : VddsMediaModel, IMultimediaObject
    {
        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaObjectId)]
        public string MultimediaObjectId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.OfficeId)]
        public string OfficeId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Type)]
        public MultimediaObjectType Type { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.TypeId)]
        public MultimediaObjectTypeId TypeId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Teeth)]
        public string Teeth { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Pregnancy)]
        public bool? Pregnancy { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.XrayComment)]
        public string XrayComment { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.XrayExposure)]
        public string XrayExposure { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.XrayCurrent)]
        public string XrayCurrent { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.XrayVoltage)]
        public string XrayVoltage { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Extension)]
        public MultimediaObjectExtension Extension { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ColorType)]
        public MultimediaObjectColorType ColorType { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Date)]
        public DateTime? Date { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Time)]
        public string Time { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Comment)]
        public string Comment { get; set; }


        public MultimediaObject()
            : base()
        {

        }


        public void WriteProperties(VddsMediaModel source, string sectionName)
        {
            Data = source.Data;

            WriteProperties(sectionName);
        }
    }
}