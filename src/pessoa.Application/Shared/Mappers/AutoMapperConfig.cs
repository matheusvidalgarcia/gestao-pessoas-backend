using AutoMapper;

namespace pessoa.Application.Shared.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Pesssoa.ModelToDTOProfile());
                cfg.AddProfile(new Endereco.ModelToDTOProfile());
            });
        }
    }
}