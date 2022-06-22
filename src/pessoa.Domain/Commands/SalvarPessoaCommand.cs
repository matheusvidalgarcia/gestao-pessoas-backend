using core.Types;
using pessoa.Domain.Models;
using pessoa.Domain.Validations;

namespace pessoa.Domain.Commands
{
    public class SalvarPessoaCommand : Command
    {
        public SalvarPessoaCommand(Pessoa pessoa)
        {
            pessoa.AddNewId();
            Pessoa = pessoa;
        }

        public Pessoa Pessoa { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new SalvarPessoaCommandValidation().Validate(Pessoa);
            return ValidationResult.IsValid;
        }
    }
}
