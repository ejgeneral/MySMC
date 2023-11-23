using Domain.Common;
using Domain.Common.Types;

namespace Domain.Entities.ProgramAggregate
{
    public class Program : BaseEntity
    {
        // Program Code
        public string Code { get; private set; } = string.Empty;

        // Program Name
        public string Name { get; private set; } = string.Empty;

        // Full Description
        public string Description { get; private set; } = string.Empty;

        // Department Code
        public string DeptCode { get; private set; } = string.Empty;

        // Type of credential earned
        public Credential Credential { get; private set; } = Credential.Undergraduate;

        // The CMO catalog version
        public string? Catalog { get; private set; } = string.Empty;

        private Program() {}
        
        public static Program Create(
            string code,
            string name,
            string description,
            string deptCode,
            Credential credential,
            string? catalog)
        {
            var t = new Program();

            Guard.Against.NullOrEmpty(code, nameof(code));
            
            t.Code = code;
            t.Name = name;
            t.Description = description;
            t.DeptCode = deptCode;
            t.Credential = credential;
            t.Catalog = catalog;

            return t;
        }
    }
}
