using Microsoft.EntityFrameworkCore;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Entidade;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Repository;
using ValidacaoConhecimentoCG.API.Infrastructure.Extensions;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Base.Service
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : EntidadeBase
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<PaginacaoResponse<TEntity>> ObterTodosPaginado(PaginacaoRequest input)
        {
            return await _repository.ObterAsNoTracking().PaginarAsync(input);
        }

        public async Task<TEntity?> ObterPorId(Guid id, bool tracking = false)
        {
            if (tracking)
            {
                return await _repository
                    .Obter()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            }

            return await _repository
                .ObterAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> Obter()
        {
            return _repository.Obter();
        }

        public IQueryable<TEntity> ObterAsNoTracking()
        {
            return _repository.ObterAsNoTracking();
        }

        public void Adicionar(TEntity entity)
        {
            _repository.Adicionar(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _repository.Atualizar(entity);
        }

        public void Remover(TEntity entity)
        {
            _repository.Remover(entity);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
