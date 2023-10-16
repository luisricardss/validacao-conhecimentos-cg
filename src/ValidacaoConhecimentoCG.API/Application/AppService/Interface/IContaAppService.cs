using ValidacaoConhecimentoCG.API.Application.Requests.Conta;
using ValidacaoConhecimentoCG.API.Application.Responses.Conta;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao;

namespace ValidacaoConhecimentoCG.API.Application.AppService.Interface
{
    public interface IContaAppService
    {
        Task<PaginacaoResponse<ContaResponse>> ObterTodosPaginado(PaginacaoRequest request);

        Task<ContaResponse?> ObterPorId(Guid id);

        Task<Guid?> Adicionar(ContaRequest request);
        
        Task<bool> Atualizar(AtualizarContaRequest request);

        Task<bool> Remover(Guid id);
    }
}
