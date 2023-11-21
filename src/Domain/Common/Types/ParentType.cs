using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Types
{
    public class ParentType : SmartEnum<ParentType>
    {
        public static readonly ParentType Father = new ParentType(nameof(Father), 1);
        public static readonly ParentType Mother = new ParentType(nameof(Mother), 2);
        public static readonly ParentType Guardian = new ParentType(nameof(Guardian), 3);

        public ParentType(string name, int value) : base(name, value)
        {
        }
    }
}
