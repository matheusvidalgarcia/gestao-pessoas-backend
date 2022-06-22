using core.Util.Validator;
using FluentValidation;
using System;

namespace pessoa.Domain.Validations
{
    public class DeletarPessoaCommandValidation : AbstractValidator<Guid>
    {
        public DeletarPessoaCommandValidation()
        {
            ValidarId();
        }

        private void ValidarId()
        {
            RuleFor(id => id).IdRule();
        }
    }
}