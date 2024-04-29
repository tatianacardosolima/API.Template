using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Domain.Commands.Request
{
    public class PessoaRequest
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; }

        public TipoPessoa TipoPessoa { get; set; }
    }
}
