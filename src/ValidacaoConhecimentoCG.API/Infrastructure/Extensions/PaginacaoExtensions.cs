using Microsoft.EntityFrameworkCore;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Extensions
{
    public static class PaginacaoExtensions
    {
        public static async Task<PaginacaoResponse<TResultItem>> PaginarAsync<TResultItem>(
            this IQueryable<TResultItem> query,
            PaginacaoRequest input,
            CancellationToken cancellationToken = new())
        {
            var numeroDaPagina = input.NumeroDaPagina < 0 ? 0 : input.NumeroDaPagina;
            var tamanhoDaPagina = input.TamanhoDaPagina < 1 ? 0 : input.TamanhoDaPagina;

            var totalDeElementos = await query.CountAsync(cancellationToken);
            var indexInicial = numeroDaPagina * tamanhoDaPagina;

            var itens = new List<TResultItem>();
            if (tamanhoDaPagina == 0 && numeroDaPagina == 0)
            {
                itens = await query.ToListAsync(cancellationToken);
            }
            else
            {
                itens = await query
                    .Skip(indexInicial)
                    .Take(tamanhoDaPagina)
                    .ToListAsync(cancellationToken);
            }

            var result = new PaginacaoResponse<TResultItem>
            {
                Itens = itens,
                Paginacao = new DadosPaginacao
                {
                    NumeroDaPagina = numeroDaPagina,
                    TamanhoDaPagina = itens.Count,
                    TotalDeElementos = totalDeElementos
                }
            };

            return result;
        }
    }
}
