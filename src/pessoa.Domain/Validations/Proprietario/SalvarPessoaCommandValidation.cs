namespace pessoa.Domain.Validations
{
    public class SalvarPessoaCommandValidation : PessoaValidation
    {
        public SalvarPessoaCommandValidation()
        {
            ValidarNome();
            ValidarSenha();
            ValidarEmail();
            ValidarTelefone();
            ValidarCrmvReponsavel();
            ValidarCnpj();
        }
    }
}