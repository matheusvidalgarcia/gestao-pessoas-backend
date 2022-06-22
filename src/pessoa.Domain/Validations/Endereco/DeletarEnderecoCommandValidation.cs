using core.Util.Validator;
using FluentValidation;
using System;

namespace pessoa.Domain.Validations
{
    public class DeletarEnderecoCommandValidation : AbstractValidator<Guid>
    {
        public DeletarEnderecoCommandValidation()
        {
            ValidarId();
        }

        private void ValidarId()
        {
            RuleFor(id => id).IdRule();
        }
    }
}