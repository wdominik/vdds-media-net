using System;

namespace VddsMediaNet
{
    public interface IPatient
    {
        string OfficeId { get; set; }

        string PatientId { get; set; }

        string InsuranceId { get; set; }

        string PatientDisplayId { get; set; }

        string AttendingPhysician { get; set; }

        string FamilyName { get; set; }

        string GivenName { get; set; }

        string Title { get; set; }

        string NameAffix { get; set; }

        string NamePrefix { get; set; }

        string MiddleName { get; set; }

        string PreferredName { get; set; }

        DateTime? DateOfBirth { get; set; }

        Sex Sex { get; set; }

        Salutation Salutation { get; set; }

        string StreetAddress { get; set; }

        string City { get; set; }

        string PostalCode { get; set; }

        string Country { get; set; }

        string StreetAddressSupplement { get; set; }

        string Employer { get; set; }

        string Occupation { get; set; }

        string PhoneHome { get; set; }

        string PhoneWork { get; set; }

        string PhoneCellular { get; set; }

        string Email { get; set; }

        HealthInsuranceType HealthInsuranceType { get; set; }

        string HealthInsuranceCompany { get; set; }

        string HealthInsuranceCompanyNumber { get; set; }

        string PolicyholderNumber { get; set; }
    }
}