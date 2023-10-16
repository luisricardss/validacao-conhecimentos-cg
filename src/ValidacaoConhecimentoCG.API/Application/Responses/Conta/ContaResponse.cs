namespace ValidacaoConhecimentoCG.API.Application.Responses.Conta
{
    public class ContaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
    }
}
