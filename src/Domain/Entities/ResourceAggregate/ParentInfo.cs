using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Common.Types;

namespace Domain.Entities.ResourceAggregate
{
    public class ParentInfo : BaseAuditableEntity
    {
        // Related Resource Id
        public Guid ResourceId { get; private set; }

        // Given names
        public string GivenNames { get; private set; } = string.Empty;

        // Middle name
        public string? MiddleName { get; private set; }

        // Family name
        public string FamilyName { get; private set; } = string.Empty;

        // Parent type
        public ParentType? ParentType { get; private set; }

        // Home telephone
        public string? HomeTelephone { get; private set; }

        // Mobile Phone
        public string? MobileTelephone { get; private set; }

        // Email 
        public string? EmailAddress { get; private set; }

        // Occupation
        public string? Occupation { get; private set; }

        // Employer name
        public string? EmployerName { get; private set; }

        // Highest education
        public string? HighestEducationAttainment { get; private set; }

        // Last school attended
        public string? SchoolAttended { get; private set; }

        // Is deceased
        public bool IsDeceased { get; private set; } = false;

        #pragma warning disable CS8618 // Required by Entity Framework
        private ParentInfo() { }

        public static ParentInfo Create(
            Guid resourceId,
            string givenNames,
            string? middleName,
            string familyName,
            ParentType? parentType,
            string? homeTelephone,
            string? mobilePhone,
            string? email,
            string? occupation,
            string? employerName,
            string? highestEducationalAttainment,
            string? schoolAttended,
            bool isDeceased)
        {
            Guard.Against.NullOrEmpty(resourceId, nameof(resourceId));

            var t = new ParentInfo();
            t.ResourceId = resourceId;
            t.GivenNames = givenNames;
            t.MiddleName = middleName;
            t.FamilyName = familyName;
            t.ParentType = parentType;
            t.HomeTelephone = homeTelephone;
            t.MobileTelephone = mobilePhone;
            t.EmailAddress = email;
            t.Occupation = occupation;
            t.EmployerName = employerName;
            t.HighestEducationAttainment = highestEducationalAttainment;
            t.SchoolAttended = schoolAttended;
            t.IsDeceased = isDeceased;

            return t;
        }
    }
}
