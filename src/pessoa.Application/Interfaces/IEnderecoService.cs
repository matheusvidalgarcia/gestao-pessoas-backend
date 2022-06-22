using FluentValidation.Results;
using pessoa.Application.DTOs.Endereco;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pessoa.Application.Interfaces
{
    public interface IEnderecoService : IDisposable
    {
        Task<IList<ListarEnderecoDTO>> Listar(Guid IdProprietario);
        Task<ObterEnderecoDTO> Obter(Guid idProprietario, Guid idEndereco);
        Task<ValidationResult> Salvar(SalvarEnderecoDTO request);
        Task<ValidationResult> Alterar(AlterarEnderecoDTO request);
        Task<ValidationResult> Deletar(Guid idProprietario, Guid idEndereco);
    }
}