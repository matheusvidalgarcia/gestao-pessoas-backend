using core.Types;
using FluentValidation.Results;
using pessoa.Domain.Validations;
using System;

namespace pessoa.Domain.Commands
{
    public class DeletarEnderecoCommand : Command
    {
        public DeletarEnderecoCommand(Guid idProprietario, Guid idEndereco)
        {
            IdProprietario = idProprietario;
            idEndereco = idEndereco;
        }

        public Guid Id { get; protected set; }
        public Guid IdProprietario { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new DeletarEnderecoCommandValidation().Validate(Id);
            return ValidationResult.IsValid;
        }
    }
}