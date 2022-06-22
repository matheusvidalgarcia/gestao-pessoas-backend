using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pessoa.Application.DTOs.Alterar
{
    [Serializable]
    public class AlterarPessoaDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid Id { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [MaxLength(18, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(18, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int CrmvReponsavel { get; set; }

        [MaxLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }

        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(6, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(11, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        public string Telefone { get; set; }
    }
}