using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using ValidacaoConhecimentoCG.API.Application.AppService.Interface;
using ValidacaoConhecimentoCG.API.Application.Responses;
using ValidacaoConhecimentoCG.API.Controllers.Base;
using ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP.Response;
using ValidacaoConhecimentoCG.API.Infrastructure.Notificacoes;

namespace ValidacaoConhecimentoCG.API.Controllers
{
    [Route("Cep")]
    public class CepController : BaseController
    {
        private readonly ICepAppService _cepAppService;

        public CepController(INotificador notificador, ICepAppService cepAppService)
            : base(notificador)
        {
            _cepAppService = cepAppService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<EnderecoViaCEPResponse?>))]
        [SwaggerOperation(Summary = "Consulta CEP")]
        public async Task<IActionResult> ObterEndereceoPorCep([FromQuery] string? cep)
        {
            var result = await _cepAppService.ObterEndereceoPorCep(cep);
            return CustomResponse(result);
        }
    }
}