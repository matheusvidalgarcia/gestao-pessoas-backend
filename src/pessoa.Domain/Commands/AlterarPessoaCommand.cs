using core.Types;
using pessoa.Domain.Models;
using pessoa.Domain.Validations;

namespace pessoa.Domain.Commands
{
    public class AlterarPessoaCommand : Command
    {
        public AlterarPessoaCommand(Pessoa pessoa)
        {
            Pessoa = pessoa;
        }

        public Pessoa Pessoa { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new AlterarPessoaCommandValidation().Validate(Pessoa);
            return ValidationResult.IsValid;
        }
    }
}
