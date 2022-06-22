using core.Types;
using pessoa.Domain.Models;
using pessoa.Domain.Validations;
using System;

namespace pessoa.Domain.Commands
{
    public class SalvarEnderecoCommand : Command
    {
        public SalvarEnderecoCommand(Guid idProprietario, Endereco endereco)
        {
            IdProprietario = idProprietario;

            endereco.AddNewId();
            Endereco = endereco;
        }

        public Guid IdProprietario { get; protected set; }
        public Endereco Endereco { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new SalvarEnderecoCommandValidation().Validate(Endereco);
            return ValidationResult.IsValid;
        }
    }
}
