using core.Patterns.MediatR;
using core.Repository.Mongo;
using core.Types;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pessoa.Application.Interfaces;
using pessoa.Application.Services;
using pessoa.Application.Shared.Mappers;
using pessoa.Domain.Commands;
using pessoa.Domain.Commands.Handler;
using pessoa.Domain.Interfaces;
using pessoa.Infra.Data.Http.Geolocalizacao;
using pessoa.Infra.Data.Respository;
using System;

namespace pessoa.Infra.DI
{
    public class Bootstrap
    {
        private static IServiceCollection _services;
        private static string _hostGeolocalizacao;
        public static void Inicializar(IServiceCollection services, IConfiguration appSettings)
        {
            _services = services;
            _hostGeolocalizacao = appSettings.GetValue<string>("ExternalRepositories:HereMaps");

            RegistrarConfiguracoes();
            RegistrarApplication();
            RegistrarDomainCommands();
            RegistrarInfra();
        }

        private static void RegistrarConfiguracoes()
        {
            _services.AddScoped<IMediatorHandler, InMemoryBus>();
            _services.AddSingleton<AutoMapper.IConfigurationProvider>(AutoMapperConfig.RegisterMappings());
        }

        private static void RegistrarDomainCommands()
        {
            _services.AddScoped<IRequestHandler<SalvarPessoaCommand, ValidationResult>, PessoaCommandHandler>();
            _services.AddScoped<IRequestHandler<AlterarPessoaCommand, ValidationResult>, PessoaCommandHandler>();
            _services.AddScoped<IRequestHandler<DeletarPessoaCommand, ValidationResult>, PessoaCommandHandler>();
            _services.AddScoped<IRequestHandler<SalvarEnderecoCommand, ValidationResult>, PessoaCommandHandler>();
            _services.AddScoped<IRequestHandler<AlterarEnderecoCommand, ValidationResult>, PessoaCommandHandler>();
            _services.AddScoped<IRequestHandler<DeletarEnderecoCommand, ValidationResult>, PessoaCommandHandler>();
        }

        private static void RegistrarApplication()
        {
            _services.AddTransient<IPessoaService, PessoaService>();
            _services.AddTransient<IEnderecoService, EnderecoService>();
        }

        private static void RegistrarInfra()
        {
            _services.AddScoped<IMongoContext, Data.Context.PessoaContext>();
            _services.AddScoped<IPessoaRepository, PessoaRepository>();

            _services.AddHttpClient<IGeolocalizacaoRepository, GeolocalizacaoHttpRepository>()
                    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(_hostGeolocalizacao));
        }
    }
}
