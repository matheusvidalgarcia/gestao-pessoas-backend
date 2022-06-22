﻿using System;

namespace pessoa.Application.DTOs.Endereco
{
    [Serializable]
    public class ObterEnderecoDTO
    {
        public string Nome { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}