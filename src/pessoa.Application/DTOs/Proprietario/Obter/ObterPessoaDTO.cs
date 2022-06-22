using System;
using System.Collections.Generic;
using System.Text;

namespace pessoa.Application.DTOs.Obter
{
    [Serializable]
    public class ObterPessoaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int CrmvReponsavel { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public IList<ObterEnderecoDTO> Enderecos { get; private set; }
    }
}
