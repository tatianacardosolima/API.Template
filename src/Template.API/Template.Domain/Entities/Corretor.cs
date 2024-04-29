using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class Corretor: Pessoa
    {
        public double Comissao { get; set; }

        public override bool Validate()
        {
            var validate = base.Validate();

            var validator = new CorretorValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                return false;
            }
            return validate;
            
        }

        internal class CorretorValidator : AbstractValidator<Corretor>
        {

            public CorretorValidator()
            {
                RuleFor(x => x.Comissao)
                    .NotEmpty()
                        .WithMessage("O campo comissão é obrigatório.");

                RuleFor(x => x.Comissao).Custom((value, context) => 
                { 
                    if (value>25)
                        context.AddFailure("A comissão deve ser no máximo 25%.");
                });
                    
            }

        }
    }
}
