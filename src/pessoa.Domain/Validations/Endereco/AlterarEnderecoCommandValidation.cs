namespace pessoa.Domain.Validations
{
    public class AlterarEnderecoCommandValidation : EnderecoValidation
    {
        public AlterarEnderecoCommandValidation()
        {
            ValidarId();
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