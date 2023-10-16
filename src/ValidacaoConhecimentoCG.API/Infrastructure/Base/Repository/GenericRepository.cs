using Microsoft.EntityFrameworkCore;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Entidade;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.UoW;
using ValidacaoConhecimentoCG.API.Infrastructure.Data.Context;
using ValidacaoConhecimentoCG.API.Infrastructure.Extensions;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Base.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable
        where TEntity : EntidadeBase
    {
        private readonly ValidacaoConhecimentoDBContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public IUnitOfWork UnitOfWork => _context;

        protected GenericRepository(ValidacaoConhecimentoDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> ObterPorId(Guid id, bool tracking = false)
        {
            if (tracking)
            {
                return await Obter()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            }

            return await ObterAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<PaginacaoResponse<TEntity>> ObterTodosPaginado(PaginacaoRequest input)
        {
            return await ObterAsNoTracking().PaginarAsync(input);
        }

        public IQueryable<TEntity> Obter()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> ObterAsNoTracking()
        {
            return Obter().AsNoTrackingWithIdentityResolution();
        }

        public void Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Remover(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
