using Domain.Common;
using MySMC.Domain.Common.Types;

namespace Domain.Entities.ResourceAggregate
{
    /// <summary>
    /// Resource Entity is a representation of a Person within the Organization. It is
    /// uniquely identified by GUID and indexed/clustered by the ID property inherited
    /// from the BaseEntity through BaseAuditableEntity.
    /// </summary>
    public class Resource : BaseAuditableEntity
    {
        // Global Unique Id ensures compatibility accross all tables and systems
        public Guid Guid { get; private set; }

        // Given names
        public string GivenNames { get; private set; } = string.Empty;

        // Middle name, optional
        public string? MiddleName { get; private set; }

        // Family name
        public string FamilyName { get; private set; } = string.Empty;

        // Gender
        public Gender? Gender { get; private set; }

        // Birthday, optional
        public DateOnly? Birthday { get; private set; }

        // Birthplace
        public string? Birthplace { get; private set; }

        // Civil status
        public CivilStatus? CivilStatus { get; private set; }

        // Nationality
        public string? Nationality { get; private set; }

        // Religion
        public string? Religion { get; private set; }

        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method Order.AddOrderItem() which includes behavior.
        private readonly List<Address> _addresses = new List<Address>();
        private readonly List<ParentInfo> _parentInfos = new List<ParentInfo>();

        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 
        public IReadOnlyCollection<Address> AddressList => _addresses.AsReadOnly();
        public IReadOnlyCollection<ParentInfo> ParentList => _parentInfos.AsReadOnly();

        #pragma warning disable CS8618 // Required by Entity Framework
        private Resource() { }

        // Static method that returns a new instance of the Resource class
        public static Resource Create(
            string givenNames,
            string? middleName,
            string familyName,
            Gender? gender,
            DateOnly? birthday,
            string? birthPlace,
            CivilStatus? civilStatus,
            string? nationality,
            string? religion)
        {
            
            var t = new Resource();
            t.Guid = Guid.NewGuid();
            t.GivenNames = givenNames;
            t.MiddleName = middleName;
            t.FamilyName = familyName;
            t.Gender = gender;
            t.Birthday = birthday;
            t.Birthplace = birthPlace;
            t.CivilStatus = civilStatus;
            t.Nationality = nationality;
            t.Religion = religion;

            return t;
        }

        /// <summary>
        /// Add an Address record
        /// </summary>
        /// <param name="address"></param>
        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        /// <summary>
        /// Add a new Parent Info record
        /// </summary>
        /// <param name="parent"></param>
        public void AddParent(ParentInfo parent) 
        { 
            _parentInfos.Add(parent);
        }
    }
}
