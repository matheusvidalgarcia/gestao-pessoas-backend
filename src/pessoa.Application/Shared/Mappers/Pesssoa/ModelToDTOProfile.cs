using AutoMapper;
using pessoa.Application.DTOs.Salvar;
using pessoa.Domain.Models;

namespace pessoa.Application.Shared.Mappers.Pesssoa
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Pessoa, DTOs.Salvar.SalvarPessoaDTO>().ReverseMap();
            CreateMap<Pessoa, DTOs.Alterar.AlterarPessoaDTO>().ReverseMap();
            CreateMap<Pessoa, DTOs.Listar.ListarPessoaDTO>().ReverseMap();
            CreateMap<Pessoa, DTOs.Obter.ObterPessoaDTO>().ReverseMap();
        }
    }
}
