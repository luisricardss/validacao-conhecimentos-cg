namespace ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao
{
    public class PaginacaoResponse<TResult>
    {
        public IEnumerable<TResult> Itens { get; set; } = Enumerable.Empty<TResult>();
        public DadosPaginacao Paginacao { get; set; } = new DadosPaginacao();
    }
}
