using ValidacaoConhecimentoCG.API.Infrastructure.Base.Entidade;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.UoW;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Base.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable
        where TEntity : EntidadeBase
    {
        IUnitOfWork UnitOfWork { get; }

        Task<PaginacaoResponse<TEntity>> ObterTodosPaginado(PaginacaoRequest input);

        Task<TEntity?> ObterPorId(Guid id, bool tracking = false);

        IQueryable<TEntity> Obter();

        IQueryable<TEntity> ObterAsNoTracking();

        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Remover(TEntity entity);
    }
}
