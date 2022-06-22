using core.Types;
using pessoa.Domain.Models;
using pessoa.Domain.Validations;
using System;

namespace pessoa.Domain.Commands
{
    public class AlterarEnderecoCommand : Command
    {
        public AlterarEnderecoCommand(Guid idProprietario, Endereco endereco)
        {
            IdProprietario = idProprietario;
            Endereco = endereco;
        }

        public Guid IdProprietario { get; protected set; }
        public Endereco Endereco { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new AlterarEnderecoCommandValidation().Validate(Endereco);
            return ValidationResult.IsValid;
        }
    }
}
