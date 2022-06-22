using core.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pessoa.Domain.Models
{
    public class Pessoa : Entity
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public int CrmvReponsavel { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Telefone { get; private set; }
        public List<Endereco> Enderecos { get; private set; }

        internal void AdicionarNovoEndereco(Endereco endereco)
        {
            if (Enderecos == null)
                Enderecos = new List<Endereco>();

            Enderecos.Add(endereco);
        }

        internal void AdicionarNovoEndereco(List<Endereco> enderecos)
        {
            if (Enderecos == null)
                Enderecos = new List<Endereco>();

            Enderecos.AddRange(enderecos);
        }

        internal void AlterarEndereco(Endereco endereco)
        {
            var novosEnderecos = Enderecos.Where(w => w.Id != endereco.Id).ToList();
            novosEnderecos.Add(endereco);

            Enderecos = novosEnderecos;
        }

        internal void RemoverEndereco(Guid idEndereco)
        {
            Enderecos = Enderecos.Where(w => w.Id != idEndereco).ToList();
        }
    }
}