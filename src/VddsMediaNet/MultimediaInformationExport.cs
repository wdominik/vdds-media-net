using System;
using System.Collections.Generic;
using System.Linq;
using VddsMediaNet.Attributes;
using VddsMediaNet.Delegate;

namespace VddsMediaNet
{
    public class MultimediaInformationExport : VddsMediaModel, IVddsMediaRequest
    {
        [VddsMediaField(VddsMediaFieldIdentifier.PatientManagementSystem, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public string PatientManagementSystem { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ImageManagementSystem, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public string ImageManagementSystem { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.OfficeId, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public string OfficeId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PatientId, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public string PatientId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PatientDisplayId, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public string PatientDisplayId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaInformationDate, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public string MultimediaInformationDate { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaInformationType, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public string MultimediaInformationType { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.UsePatientManagementSystemImport, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public bool? UsePatientManagementSystemImport { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Ready, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public bool? Ready { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ErrorLevel, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public int? ErrorLevel { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ErrorText, Section = VddsMediaSectionIdentifier.MultimediaInformationExportSection)]
        public string ErrorText { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Count, Section = "MMOS")]
        public int? Count { get; set; }


        public IVddsMediaDelegate Delegate { get; set; }


        private IList<MultimediaObject> MultimediaObjects { get; set; } = new List<MultimediaObject>();


        public MultimediaInformationExport()
            : base()
        {

        }

        public MultimediaInformationExport(string path, bool create = false)
            : base(path, create)
        {

        }


        public void Process()
        {
            ReadProperties();
        }

        public void Responde()
        {
            // TODO: UsePatientManagementSystemImport Workflow

            try
            {
                var multimediaObjects = Delegate?.GetMultimediaObjectsForPatient(PatientId);

                if (multimediaObjects != null)
                {
                    MultimediaObjects = new List<MultimediaObject>(multimediaObjects);
                }
            }
            catch (Exception ex)
            {
                ErrorLevel = 1;
                ErrorText = ex.Message;
            }

            Ready = true;

            if (!ErrorLevel.HasValue)
            {
                ErrorLevel = 0;
            }

            Count = MultimediaObjects?.Count ?? 0;

            WriteProperties();

            if (MultimediaObjects.Any())
            {
                var index = 1;

                foreach (var multimediaObject in MultimediaObjects)
                {
                    multimediaObject.WriteProperties(this, $"MMO{index}");

                    index += 1;
                }
            }

            Write();
        }


        public static bool IsRequest(string path)
        {
            return ContainsSection(path, VddsMediaSectionIdentifier.MultimediaInformationExportSection);
        }
    }
}