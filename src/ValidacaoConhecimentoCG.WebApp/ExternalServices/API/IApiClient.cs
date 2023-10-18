using ValidacaoConhecimentoCG.WebApp.ExternalServices.API.Request;
using ValidacaoConhecimentoCG.WebApp.ExternalServices.API.Response;
using ValidacaoConhecimentoCG.WebApp.Models;

namespace ValidacaoConhecimentoCG.WebApp.ExternalServices.API
{
    public interface IApiClient
    {
        Task<Guid?> AdicionarConta(ContaViewModel conta);
        
        Task<bool?> AtualizarConta(ContaViewModel conta);
        
        Task<bool?> RemoverConta(Guid Id);

        Task<ContaViewModel?> ObterContaPorId(Guid id);

        Task<PaginacaoResponse<ContaViewModel>?> ObterContas();

        Task<EnderecoResponse?> ObterEnderecoPorCep(string cep);
    }
}
