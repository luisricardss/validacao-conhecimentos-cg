using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using ValidacaoConhecimentoCG.API.Application.AppService.Interface;
using ValidacaoConhecimentoCG.API.Application.Requests.Conta;
using ValidacaoConhecimentoCG.API.Application.Responses;
using ValidacaoConhecimentoCG.API.Application.Responses.Conta;
using ValidacaoConhecimentoCG.API.Controllers.Base;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao;
using ValidacaoConhecimentoCG.API.Infrastructure.Notificacoes;

namespace ValidacaoConhecimentoCG.API.Controllers
{
    [Route("Conta")]
    public class ContaController : BaseController
    {
        private readonly IContaAppService _contaAppService;

        public ContaController(INotificador notificador, IContaAppService contaAppService)
            : base(notificador)
        {
            _contaAppService = contaAppService;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<Guid>))]
        [SwaggerOperation(Summary = "Adicionar conta")]
        public async Task<IActionResult> Adicionar([FromBody] ContaRequest request)
        {
            var result = await _contaAppService.Adicionar(request);
            return CustomResponse(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<bool>))]
        [SwaggerOperation(Summary = "Atualizar conta")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarContaRequest request)
        {
            var result = await _contaAppService.Atualizar(request);
            return CustomResponse(result);
        }

        [HttpDelete("{id:guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<bool>))]
        [SwaggerOperation(Summary = "Remover conta")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var result = await _contaAppService.Remover(id);
            return CustomResponse(result);
        }

        [HttpGet("{id:guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<ContaResponse?>))]
        [SwaggerOperation(Summary = "Obter conta por id")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var result = await _contaAppService.ObterPorId(id);
            return CustomResponse(result);
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<PaginacaoResponse<ContaResponse>>))]
        [SwaggerOperation(Summary = "Obter todas as contas")]
        public async Task<IActionResult> Obter([FromQuery] PaginacaoRequest request)
        {
            var response = await _contaAppService.ObterTodosPaginado(request);
            return CustomResponse(response);
        }
    }
}