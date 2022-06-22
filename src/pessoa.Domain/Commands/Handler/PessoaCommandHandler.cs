using core.Types;
using FluentValidation.Results;
using MediatR;
using pessoa.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static core.Messages.Validators.Messages;

namespace pessoa.Domain.Commands.Handler
{
    public class PessoaCommandHandler : CommandHandler,
        IRequestHandler<SalvarPessoaCommand, ValidationResult>,
        IRequestHandler<AlterarPessoaCommand, ValidationResult>,
        IRequestHandler<DeletarPessoaCommand, ValidationResult>,
        IRequestHandler<SalvarEnderecoCommand, ValidationResult>,
        IRequestHandler<AlterarEnderecoCommand, ValidationResult>,
        IRequestHandler<DeletarEnderecoCommand, ValidationResult>
    {
        private readonly IPessoaRepository _repository;
        private readonly IGeolocalizacaoRepository _geolocalizacaoRepository;
        public PessoaCommandHandler(IPessoaRepository pessoaRepository, IGeolocalizacaoRepository geolocalizacaoRepository)
        {
            _repository = pessoaRepository;
            _geolocalizacaoRepository = geolocalizacaoRepository;
        }

        public async Task<ValidationResult> Handle(SalvarPessoaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var novaPessoa = command.Pessoa;

            var emailAlreadyExists = await _repository.GetByEmail(novaPessoa.Email);
            if (emailAlreadyExists != null)
            {
                AddError(Erros.RegistroEmailExistente);
                return Notification;
            }

            _repository.Add(novaPessoa);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarPessoaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var pessoaAlterada = command.Pessoa;

            var pessoaExists = await _repository.GetById(pessoaAlterada.Id);
            if (pessoaExists == null)
            {
                AddError(Erros.RegistroNaoEncontrado);
                return Notification;
            }

            var emailAlreadyExists = await _repository.GetByEmail(pessoaAlterada.Email);
            if (emailAlreadyExists != null && emailAlreadyExists.Id != pessoaAlterada.Id)
            {
                AddError(Erros.RegistroEmailExistente);
                return Notification;
            }

            pessoaAlterada.AdicionarNovoEndereco(pessoaExists.Enderecos);

            _repository.Add(pessoaAlterada);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeletarPessoaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var pessoaExists = await _repository.GetById(command.Id);
            if (pessoaExists == null)
            {
                AddError(Erros.RegistroNaoEncontrado);
                return Notification;
            }

            _repository.Remove(pessoaExists.Id);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(SalvarEnderecoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var novoEndereco = command.Endereco;

            var proprietarioExists = await _repository.GetById(command.IdProprietario);
            if (proprietarioExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Proprietario"));
                return Notification;
            }

            var geolocalizacaoExists = await _geolocalizacaoRepository.GetLocalizacaoAsync(novoEndereco.Rua, novoEndereco.Numero, novoEndereco.Cidade, novoEndereco.Estado, novoEndereco.Pais);
            if (geolocalizacaoExists == null)
            {
                AddError(Erros.EnderecoNaoEncontrado);
                return Notification;
            }

            novoEndereco.AdicionarGeolocalizacao(geolocalizacaoExists.Latitude, geolocalizacaoExists.Longitude);
            proprietarioExists.AdicionarNovoEndereco(novoEndereco);

            _repository.Update(proprietarioExists);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarEnderecoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var enderecoAlterado = command.Endereco;

            var proprietarioExists = await _repository.GetById(command.IdProprietario);
            if (proprietarioExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Proprietario"));
                return Notification;
            }

            var enderecoExists = proprietarioExists.Enderecos.Where(w => w.Id == enderecoAlterado.Id);
            if (proprietarioExists == null)
            {
                AddError(Erros.EnderecoNaoEncontrado);
                return Notification;
            }

            var geolocalizacaoExists = await _geolocalizacaoRepository.GetLocalizacaoAsync(enderecoAlterado.Rua, enderecoAlterado.Numero, enderecoAlterado.Cidade, enderecoAlterado.Estado, enderecoAlterado.Pais);
            if (geolocalizacaoExists == null)
            {
                AddError(Erros.EnderecoNaoEncontrado);
                return Notification;
            }

            enderecoAlterado.AdicionarGeolocalizacao(geolocalizacaoExists.Latitude, geolocalizacaoExists.Longitude);
            proprietarioExists.AlterarEndereco(enderecoAlterado);

            _repository.Update(proprietarioExists);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeletarEnderecoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var pessoaExists = await _repository.GetById(command.Id);
            if (pessoaExists == null)
            {
                AddError(Erros.RegistroNaoEncontrado);
                return Notification;
            }

            pessoaExists.RemoverEndereco(command.Id);

            _repository.Update(pessoaExists);
            return await Commit(_repository.UnitOfWork);
        }
    }
}
