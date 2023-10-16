using ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Base.Service
{
    public interface IGenericService<TEntity> : IDisposable
        where TEntity : class
    {
        Task<PaginacaoResponse<TEntity>> ObterTodosPaginado(PaginacaoRequest input);

        Task<TEntity?> ObterPorId(Guid id, bool tracking = false);

        IQueryable<TEntity> Obter();

        IQueryable<TEntity> ObterAsNoTracking();

        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Remover(TEntity entity);
    }
}
