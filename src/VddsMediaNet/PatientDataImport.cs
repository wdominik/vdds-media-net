using System;
using VddsMediaNet.Attributes;
using VddsMediaNet.Delegate;

namespace VddsMediaNet
{
    public class PatientDataImport : VddsMediaModel, IVddsMediaRequest, IPatient
    {
        [VddsMediaField(VddsMediaFieldIdentifier.PatientManagementSystem, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PatientManagementSystem { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ImageManagementSystem, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string ImageManagementSystem { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.OfficeId, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string OfficeId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PatientId, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PatientId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.InsuranceId, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string InsuranceId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PatientDisplayId, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PatientDisplayId { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.AttendingPhysician, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string AttendingPhysician { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.FamilyName, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string FamilyName { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.GivenName, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string GivenName { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Title, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string Title { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.NameAffix, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string NameAffix { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.NamePrefix, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string NamePrefix { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MiddleName, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string MiddleName { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PreferredName, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PreferredName { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.DateOfBirth, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public DateTime? DateOfBirth { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Sex, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public Sex Sex { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Salutation, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public Salutation Salutation { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.StreetAddress, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string StreetAddress { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.City, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string City { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PostalCode, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PostalCode { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Country, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string Country { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.StreetAddressSupplement, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string StreetAddressSupplement { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Employer, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string Employer { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Occupation, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string Occupation { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PhoneHome, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PhoneHome { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PhoneWork, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PhoneWork { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PhoneCellular, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PhoneCellular { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Email, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string Email { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.HealthInsuranceType, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public HealthInsuranceType HealthInsuranceType { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.HealthInsuranceCompany, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string HealthInsuranceCompany { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.HealthInsuranceCompanyNumber, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string HealthInsuranceCompanyNumber { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.PolicyholderNumber, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string PolicyholderNumber { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.GenerateMultimediaInformation, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public bool? GenerateMultimediaInformation { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaInformationDate, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string MultimediaInformationDate { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.MultimediaInformationType, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string MultimediaInformationType { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.UsePatientManagementSystemImport, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public bool? UsePatientManagementSystemImport { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.IsInformation, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public bool? IsInformation { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Ready, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public bool? Ready { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ErrorLevel, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public int? ErrorLevel { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ErrorText, Section = VddsMediaSectionIdentifier.PatientDataImportSecion)]
        public string ErrorText { get; set; }

        public IVddsMediaDelegate Delegate { get; set; }


        public PatientDataImport()
            : base()
        {

        }

        public PatientDataImport(string path, bool create = false)
            : base(path, create)
        {

        }


        public void Process()
        {
            ReadProperties();

            try
            {
                Delegate?.ImportPatient(this);
            }
            catch (Exception ex)
            {
                ErrorLevel = 1;
                ErrorText = ex.Message;
            }

            if (!IsInformation.HasValue || !IsInformation.Value)
            {
                try
                {
                    Delegate?.ShowPatient(PatientId);
                }
                catch (Exception ex)
                {
                    ErrorLevel = 1;
                    ErrorText = ex.Message;
                }
            }
        }

        public void Responde()
        {
            // TODO: GenerateMultimediaInformation/UsePatientManagementSystemImport Workflow

            Ready = true;

            if (!ErrorLevel.HasValue)
            {
                ErrorLevel = 0;
            }

            WriteProperties();

            Write();
        }


        public static bool IsRequest(string path)
        {
            return ContainsSection(path, VddsMediaSectionIdentifier.PatientDataImportSecion);
        }
    }
}