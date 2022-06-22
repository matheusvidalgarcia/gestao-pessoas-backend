using pessoa.Domain.Models;
using core.Repository;
using System.Threading.Tasks;
using System;

namespace pessoa.Domain.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Pessoa> GetByEmail(string email);
        Task<Pessoa> GetEnderecoById(Guid idPorprietario, Guid idEndereco);
        Task<Pessoa> GetEnderecos(Guid idPorprietario);
    }
}
