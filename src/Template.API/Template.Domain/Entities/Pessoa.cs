using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.Abstractions.Entities;
using static Template.Domain.Entities.Pessoa;

namespace Template.Domain.Entities
{
    public enum TipoPessoa {
        Fisica = 1, Juridica = 2
    }
    public class Pessoa : AuditEntityBase
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }

        public string Email{ get; set; }
        public string Telefone { get; set; }

        public TipoPessoa TipoPessoa { get; set; }
        public override bool Validate()
        {
            var validator = new PessoaValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                return false;
            }
            return true;
        }

        internal class PessoaValidator : AbstractValidator<Pessoa>
        {

            public PessoaValidator()
            {               
                RuleFor(x => x.Nome)                    
                    .NotEmpty()
                        .WithMessage("O campo nome é obrigatório.");

                RuleFor(x => x.CpfCnpj)
                    .NotEmpty()
                        .WithMessage("O campo cpf/cnpj é obrigatório.");

                RuleFor(x => x.Email)
                    .NotEmpty()
                        .WithMessage("O campo email é obrigatório.");

                RuleFor(x => x.TipoPessoa)
                    .NotEmpty()
                        .WithMessage("O campo tipo de pessoa é obrigatório.");
            }

        }

    }
}
