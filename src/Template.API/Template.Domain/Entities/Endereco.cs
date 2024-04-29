using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.Abstractions.Entities;

namespace Template.Domain.Entities
{
    public class Endereco : AuditEntityBase
    {

        public string Logradouro { get; set; }
        public string? Numero { get; set; }

        public string CEP { get; set; }
        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
