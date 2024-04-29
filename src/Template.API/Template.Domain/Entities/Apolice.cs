using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.Abstractions.Entities;

namespace Template.Domain.Entities
{
    public class Apolice : AuditEntityBase
    {
        public string NumeroApolice { get; set; }
        public string NumeroEndosso { get; set; }

        public DateTime DataEmissao { get; set; }

        public Modalidade Modalidade { get; set; }
        public int ModalidadeId { get; set; }

        public Proposta Proposta { get; set; }
        public int PropostaId { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
