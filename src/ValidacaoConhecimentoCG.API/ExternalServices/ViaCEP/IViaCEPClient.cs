using ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP.Response;

namespace ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP
{
    public interface IViaCEPClient
    {
        Task<EnderecoViaCEPResponse?> ObterEndereco(string cep);
    }
}
