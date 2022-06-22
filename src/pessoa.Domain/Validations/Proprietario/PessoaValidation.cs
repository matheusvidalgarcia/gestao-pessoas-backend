
using FluentValidation;
using static core.Messages.Validators.Messages;
using static core.Util.Validator.CustomValidators;

namespace pessoa.Domain.Validations
{
    public abstract class PessoaValidation : core.Types.AbstractValidator<Models.Pessoa>
    {
        protected void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(2, 150).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue)
                .EmailAddressRule().WithMessage(FluentValidator.CampoInvalido);
        }
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(2, 100).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue);
        }
        protected void ValidarSenha()
        {
            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(6, 10).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue);
        }
        protected void ValidarTelefone()
        {
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(10, 11).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue)
                .MatchPhoneNumberRule().WithMessage(FluentValidator.CampoInvalido); 
        }
        protected void ValidarCrmvReponsavel()
        {
            RuleFor(c => c.CrmvReponsavel)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio);
        }
        protected void ValidarCnpj()
        {
            RuleFor(c => c.Cnpj)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(18, 18).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue)
                .CNPJRule().WithMessage(FluentValidator.CampoInvalido);
        }
    }
}
