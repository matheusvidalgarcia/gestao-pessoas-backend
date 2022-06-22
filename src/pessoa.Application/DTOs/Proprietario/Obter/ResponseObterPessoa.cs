using FluentValidation.Results;
using System;

namespace pessoa.Application.DTOs.Obter
{
    [Serializable]
    public class ResponseObterPessoa : ValidationResult
    {
        public ObterPessoaDTO Pessoa { get; set; }
    }
}
