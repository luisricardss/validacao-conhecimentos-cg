using ValidacaoConhecimentoCG.API.Domain.Entidades;
using ValidacaoConhecimentoCG.API.Domain.Repository;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Repository;
using ValidacaoConhecimentoCG.API.Infrastructure.Data.Context;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Data.Repository
{
    public class ContaRepository : GenericRepository<Conta>, IContaRepository
    {
        protected ContaRepository(ValidacaoConhecimentoDBContext context) : base(context)
        {
        }
    }
}
