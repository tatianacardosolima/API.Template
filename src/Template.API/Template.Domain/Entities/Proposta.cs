using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.Abstractions.Entities;

namespace Template.Domain.Entities
{
    public enum PropostaStatus
    { 
        Criado = 0,
        Analise_Credito = 1,
        Aguardando_Aprovacao_Cliente = 2,
        Cancelado_Pelo_Cliente = 3,
        Aprovado_Pelo_Cliente = 4,
        Aguardando_Emissao_Apolice = 5,
        Apolice_Emitida = 6,
        Cancelado_Seguradora = 7,
        Expirado = 8
    }

    public class Proposta : AuditEntityBase
    {
        public string NumeroProposta { get; set; }
        public string NumeroEndosso { get; set; }
        public DateTime DataUltimoStatus { get; set; }
        public PropostaStatus UltimoStatus { get; set; }

        public Segurado Segurado { get; set; }
        public int SeguradoId { get; set; }

        public Seguradora Seguradora { get; set; }
        public int SeguradoraId { get; set; }


        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
