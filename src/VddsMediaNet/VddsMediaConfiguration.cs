using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using VddsMediaNet.Attributes;
using VddsMediaNet.Converters;
using VddsMediaNet.Exceptions;

namespace VddsMediaNet
{
    public class VddsMediaConfiguration : VddsMediaModel
    {
        public SystemType SystemType { get; set; }

        public string SectionName { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Name)]
        public string Name { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.VddsMediaVersion)]
        public VddsMediaVersion VddsMediaVersion { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Stages)]
        public string Stages { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.SupportInformation)]
        public bool SupportInformation { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PatientDataImportPath)]
        public string PatientDataImportPath { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PatientDataImportOs)]
        public OperationSystem PatientDataImportOs { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaInformationExportPath)]
        public string MultimediaInformationExportPath { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaInformationExportOs)]
        public OperationSystem MultimediaInformationExportOs { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaExportPath)]
        public string MultimediaExportPath { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaExportOs)]
        public OperationSystem MultimediaExportOs { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaViewerPath)]
        public string MultimediaViewerPath { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaViewerOs)]
        public OperationSystem MultimediaViewerOs { get; set; }


        public static string DefaultConfigurationPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "VDDS_MMI.INI");


        public VddsMediaConfiguration()
            : base(DefaultConfigurationPath, create: true)
        {

        }


        public void Register()
        {
            if (SystemType != SystemType.ImageManagementSystem)
            {
                throw new NotImplementedException("Currently only image management systems are supported");
            }

            var systemType = new EnumConverter().Convert(SystemType);

            var sectionNumber = 1;

            if (Data.Sections.ContainsSection(systemType))
            {
                var regex = new Regex(@"NAME(\d+)");

                foreach (var key in Data[systemType])
                {
                    var match = regex.Match(key.KeyName);

                    if (match.Success)
                    {
                        if (key.Value == SectionName)
                        {
                            throw new AlreadyRegisteredException();
                        }

                        var candidate = int.Parse(match.Groups[1].Value);

                        if (candidate >= sectionNumber)
                        {
                            sectionNumber = candidate + 1;
                        }
                    }
                }
            }
            else
            {
                Data.Sections.AddSection(systemType);
            }

            Data[systemType].AddKey($"NAME{sectionNumber}", SectionName);

            if (Data.Sections.ContainsSection(SectionName))
            {
                throw new AlreadyRegisteredException();
            }

            Data.Sections.AddSection(SectionName);

            WriteProperties(SectionName);

            Write();
        }

        public void Unregister()
        {
            if (SystemType != SystemType.ImageManagementSystem)
            {
                throw new NotImplementedException("Currently only image management systems are supported");
            }

            var systemType = new EnumConverter().Convert(SystemType);

            if (Data.Sections.ContainsSection(systemType))
            {
                foreach (var key in Data[systemType])
                {
                    if (key.Value == SectionName)
                    {
                        Data[systemType].RemoveKey(key.KeyName);

                        break;
                    }
                }

                if (!Data[systemType].Any())
                {
                    Data.Sections.RemoveSection(systemType);
                }
            }

            if (Data.Sections.ContainsSection(SectionName))
            {
                Data.Sections.RemoveSection(SectionName);
            }

            Write();
        }
    }
}