namespace pessoa.Domain.Validations
{
    public class AlterarPessoaCommandValidation : PessoaValidation
    {
        public AlterarPessoaCommandValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarSenha();
            ValidarEmail();
            ValidarTelefone();
            ValidarCrmvReponsavel();
            ValidarCnpj();
        }
    }
}