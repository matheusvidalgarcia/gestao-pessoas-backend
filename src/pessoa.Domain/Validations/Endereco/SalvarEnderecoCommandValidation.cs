namespace pessoa.Domain.Validations
{
    public class SalvarEnderecoCommandValidation : EnderecoValidation
    {
        public SalvarEnderecoCommandValidation()
        {
            ValidarNome();
            ValidarRua();
            ValidarComplemento();
            ValidarCep();
            ValidarCidade();
            ValidarEstado();
            ValidarPais();
        }
    }
}