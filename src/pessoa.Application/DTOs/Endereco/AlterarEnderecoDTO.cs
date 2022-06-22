using System;
using System.ComponentModel.DataAnnotations;

namespace pessoa.Application.DTOs.Endereco
{
    public class AlterarEnderecoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid IdProprietario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid Id { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [MaxLength(150, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        [MaxLength(9, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(9, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cep { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Estado { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Pais { get; set; }
    }
}