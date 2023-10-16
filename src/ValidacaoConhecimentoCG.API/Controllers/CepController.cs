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
        public IActionResult Remover([FromQuery] string? cep)
        {
            var result = _cepAppService.ObterEndereceoPorCep(cep);
            return CustomResponse(result);
        }
    }
}