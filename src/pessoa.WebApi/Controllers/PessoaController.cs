using core.API;
using core.Messages;
using Microsoft.AspNetCore.Mvc;
using pessoa.Application.DTOs.Alterar;
using pessoa.Application.DTOs.Salvar;
using pessoa.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace pessoa.WebApi.Controllers
{
    public class PessoaController : ApiController
    {
        private readonly IPessoaService _service;
        private readonly IEnderecoService _serviceEndereco;
        public PessoaController(IPessoaService service, IEnderecoService serviceEndereco)
        {
            _service = service;
            _serviceEndereco = serviceEndereco;
        }

        [HttpPost]
        [Route("proprietario")]
        public async Task<IActionResult> Salvar([FromBody] SalvarPessoaDTO request)
        {
            if (!ModelState.IsValid)
                return ResponseRequetErrors();

            var response = await _service.Salvar(request);
            return ResponseHttp(response);
        }

        [HttpPut]
        [Route("proprietario")]
        public async Task<IActionResult> Alterar([FromBody] AlterarPessoaDTO request)
        {
            if (!ModelState.IsValid)
                return ResponseRequetErrors();

            var response = await _service.Alterar(request);
            return ResponseHttp(response);
        }

        [HttpDelete]
        [Route("proprietario/{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var response = await _service.Deletar(id);
            return ResponseHttp(response);
        }

        [HttpGet]
        [Route("proprietario")]
        public async Task<IActionResult> Listar()
        {
            var response = await _service.Listar();
            return ResponseHttp(response);
        }

        [HttpGet]
        [Route("proprietario/{id:guid}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var response = await _service.Obter(id);
            return ResponseHttp(response);
        }

        [HttpPost]
        [Route("proprietario/{id:guid}/endereco")]
        public async Task<IActionResult> Salvar([FromBody] Application.DTOs.Endereco.SalvarEnderecoDTO request)
        {
            if (!ModelState.IsValid)
                return ResponseRequetErrors();

            var response = await _serviceEndereco.Salvar(request);
            return ResponseHttp(response);
        }

        [HttpPut]
        [Route("proprietario/{id:guid}/endereco")]
        public async Task<IActionResult> Alterar([FromBody] Application.DTOs.Endereco.AlterarEnderecoDTO request)
        {
            if (!ModelState.IsValid)
                return ResponseRequetErrors();

            var response = await _serviceEndereco.Alterar(request);
            return ResponseHttp(response);
        }

        [HttpDelete]
        [Route("proprietario/{id:guid}/endereco/{idEndereco:guid}")]
        public async Task<IActionResult> Deletar(Guid id, Guid idEndereco)
        {
            var response = await _serviceEndereco.Deletar(id, idEndereco);
            return ResponseHttp(response);
        }

        [HttpGet]
        [Route("proprietario/{id:guid}/enderecos")]
        public async Task<IActionResult> Listar(Guid id)
        {
            var response = await _serviceEndereco.Listar(id);
            return ResponseHttp(response);
        }

        [HttpGet]
        [Route("proprietario/{id:guid}/endereco/{idEndereco:guid}")]
        public async Task<IActionResult> Obter(Guid id, Guid idEndereco)
        {
            var response = await _serviceEndereco.Obter(id, idEndereco);
            return ResponseHttp(response);
        }
    }
}
