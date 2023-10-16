using ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP.Response;

namespace ValidacaoConhecimentoCG.API.Application.AppService.Interface
{
    public interface ICepAppService
    {
        Task<EnderecoViaCEPResponse?> ObterEndereceoPorCep(string? cep);
    }
}
