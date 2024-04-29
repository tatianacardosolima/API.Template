using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.Abstractions.Entities;

namespace Template.Domain.Entities
{
    public class Modalidade : AuditEntityBase
    {
        public string Nome { get; set; }
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
