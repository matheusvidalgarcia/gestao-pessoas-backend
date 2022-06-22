
using FluentValidation;
using static core.Messages.Validators.Messages;

namespace pessoa.Domain.Validations
{
    public abstract class EnderecoValidation : core.Types.AbstractValidator<Models.Endereco>
    {
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(2, 50).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue);
        }

        protected void ValidarRua()
        {
            RuleFor(c => c.Rua)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(2, 150).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue);
        }

        protected void ValidarComplemento()
        {
            RuleFor(c => c.Complemento)
                .Length(2, 50).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue).When(w => !string.IsNullOrWhiteSpace(w.Complemento));
        }

        protected void ValidarCep()
        {
            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(9, 9).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue);
        }

        protected void ValidarCidade()
        {
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(2, 150).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue);
        }

        protected void ValidarEstado()
        {
            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(2, 2).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue);
        }

        protected void ValidarPais()
        {
            RuleFor(c => c.Pais)
                .NotEmpty().WithMessage(FluentValidator.CampoObrigatorio)
                .Length(2, 50).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue);
        }
    }
}
