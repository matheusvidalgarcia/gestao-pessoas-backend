using AutoMapper;
using core.Patterns.MediatR;
using FluentValidation.Results;
using pessoa.Application.DTOs.Endereco;
using pessoa.Application.Interfaces;
using pessoa.Domain.Commands;
using pessoa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pessoa.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IPessoaRepository _repository;
        public EnderecoService(IPessoaRepository pessoaRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _repository = pessoaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<ValidationResult> Salvar(SalvarEnderecoDTO request)
        {
            var enderecoModel = _mapper.Map<Domain.Models.Endereco>(request);
            var salvarCommand = new SalvarEnderecoCommand(request.IdProprietario, enderecoModel);

            return await _mediator.SendCommand(salvarCommand);
        }

        public async Task<IList<ListarEnderecoDTO>> Listar(Guid idProprietario)
        {
            var responseRepository = await _repository.GetEnderecos(idProprietario);
            return _mapper.Map<IList<ListarEnderecoDTO>>(responseRepository);
        }

        public async Task<ObterEnderecoDTO> Obter(Guid idProprietario, Guid idEndereco)
        {
            var responseRepository = await _repository.GetEnderecoById(idProprietario, idEndereco);
            return _mapper.Map<ObterEnderecoDTO>(responseRepository);
        }

        public async Task<ValidationResult> Alterar(AlterarEnderecoDTO request)
        {
            var enderecoModel = _mapper.Map<Domain.Models.Endereco>(request);
            var alterarCommand = new AlterarEnderecoCommand(request.IdProprietario, enderecoModel);

            return await _mediator.SendCommand(alterarCommand);
        }

        public async Task<ValidationResult> Deletar(Guid idProprietario, Guid idEndereco)
        {
            var deletarCommand = new DeletarEnderecoCommand(idProprietario, idEndereco);
            return await _mediator.SendCommand(deletarCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
