using AutoMapper;
using core.Patterns.MediatR;
using FluentValidation.Results;
using pessoa.Application.DTOs.Alterar;
using pessoa.Application.DTOs.Listar;
using pessoa.Application.DTOs.Obter;
using pessoa.Application.DTOs.Salvar;
using pessoa.Application.Interfaces;
using pessoa.Domain.Commands;
using pessoa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pessoa.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IPessoaRepository _repository;
        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _repository = pessoaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<ValidationResult> Salvar(SalvarPessoaDTO request)
        {
            var pessoaModel = _mapper.Map<Domain.Models.Pessoa>(request);
            var salvarCommand = new SalvarPessoaCommand(pessoaModel);

            return await _mediator.SendCommand(salvarCommand);
        }

        public async Task<IList<ListarPessoaDTO>> Listar()
        {
            var responseRepository = await _repository.GetAll();
            return _mapper.Map<IList<ListarPessoaDTO>>(responseRepository);
        }

        public async Task<ObterPessoaDTO> Obter(Guid id)
        {
            var responseRepository = await _repository.GetById(id);
            return _mapper.Map<ObterPessoaDTO>(responseRepository);
        }

        public async Task<ValidationResult> Alterar(AlterarPessoaDTO request)
        {
            var pessoaModel = _mapper.Map<Domain.Models.Pessoa>(request);
            var alterarCommand = new AlterarPessoaCommand(pessoaModel);

            return await _mediator.SendCommand(alterarCommand);
        }

        public async Task<ValidationResult> Deletar(Guid id)
        {
            var deletarCommand = new DeletarPessoaCommand(id);
            return await _mediator.SendCommand(deletarCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
