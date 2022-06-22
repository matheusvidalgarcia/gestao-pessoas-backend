using FluentValidation.Results;
using pessoa.Application.DTOs.Alterar;
using pessoa.Application.DTOs.Listar;
using pessoa.Application.DTOs.Obter;
using pessoa.Application.DTOs.Salvar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pessoa.Application.Interfaces
{
    public interface IPessoaService : IDisposable
    {
        Task<IList<ListarPessoaDTO>> Listar();
        Task<ObterPessoaDTO> Obter(Guid id);
        Task<ValidationResult> Salvar(SalvarPessoaDTO request);
        Task<ValidationResult> Alterar(AlterarPessoaDTO request);
        Task<ValidationResult> Deletar(Guid id);
    }
}
