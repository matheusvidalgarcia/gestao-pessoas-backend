using System;

namespace pessoa.Application.DTOs.Listar
{
    [Serializable]
    public class ListarPessoaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int CrmvReponsavel { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
    }
}
