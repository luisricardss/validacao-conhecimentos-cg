namespace ValidacaoConhecimentoCG.WebApp.ExternalServices.API.Request
{
    public class PaginacaoRequest
    {
        public int TamanhoDaPagina { get; set; }

        /// <summary>
        /// O número da pagina, iniciando em 0
        /// </summary>
        public int NumeroDaPagina { get; set; }
    }
}
