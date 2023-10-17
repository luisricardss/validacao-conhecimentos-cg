namespace ValidacaoConhecimentoCG.WebApp.ExternalServices.API.Response
{
    public class PaginacaoResponse<TResult>
    {
        public IEnumerable<TResult> Itens { get; set; } = Enumerable.Empty<TResult>();
        public DadosPaginacaoResponse Paginacao { get; set; } = new DadosPaginacaoResponse();
    }
}
