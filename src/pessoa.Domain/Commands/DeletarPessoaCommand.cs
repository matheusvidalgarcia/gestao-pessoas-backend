using core.Types;
using FluentValidation.Results;
using pessoa.Domain.Validations;
using System;

namespace pessoa.Domain.Commands
{
    public class DeletarPessoaCommand : Command
    {
        public DeletarPessoaCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new DeletarPessoaCommandValidation().Validate(Id);
            return ValidationResult.IsValid;
        }
    }
}