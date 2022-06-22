using core.Repository;
using core.Repository.Mongo;
using core.Repository.UnitOfWork;
using MongoDB.Driver;
using pessoa.Domain.Interfaces;
using pessoa.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.Infra.Data.Respository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        protected readonly IMongoContext Db;
        public PessoaRepository(IMongoContext context) : base(context)
        {
            Db = context;
        }

        public override IUnitOfWork UnitOfWork => Db;

        public virtual async Task<Pessoa> GetByEmail(string email)
        {
            var data = await DbSet.FindAsync(Builders<Pessoa>.Filter.Eq("Email", email));
            return data.FirstOrDefault();
        }

        public virtual async Task<Pessoa> GetEnderecoById(Guid idPorprietario, Guid idEndereco)
        {
            var filter = Builders<Pessoa>.Filter.And(
                           Builders<Pessoa>.Filter.Where(pessoa => pessoa.Id == idPorprietario),
                           Builders<Pessoa>.Filter.Eq("Endereco._id", idEndereco));

            var data = await DbSet.FindAsync(filter);
            return data.FirstOrDefault();
        }

        public virtual async Task<Pessoa> GetEnderecos(Guid idPorprietario)
        {
            var data = await DbSet.FindAsync(Builders<Pessoa>.Filter.Eq("_id", idPorprietario));
            return data.FirstOrDefault();
        }
    }
}