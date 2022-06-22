using AutoMapper;
using pessoa.Domain.Models;

namespace pessoa.Application.Shared.Mappers.Endereco
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Domain.Models.Endereco, DTOs.Endereco.AlterarEnderecoDTO>().ReverseMap();
            CreateMap<Domain.Models.Endereco, DTOs.Endereco.SalvarEnderecoDTO>().ReverseMap();
            CreateMap<Domain.Models.Endereco, DTOs.Endereco.ObterEnderecoDTO>().ReverseMap();
            CreateMap<Domain.Models.Endereco, DTOs.Endereco.ListarEnderecoDTO>().ReverseMap();

            CreateMap<Domain.Models.Endereco, DTOs.Obter.ObterEnderecoDTO>().ReverseMap();
        }
    }
}
