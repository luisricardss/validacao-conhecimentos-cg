using ValidacaoConhecimentoCG.API.Infrastructure.Base.Entidade;

namespace ValidacaoConhecimentoCG.API.Domain.Entidades
{
    public class Conta : EntidadeBase
    {
        public Conta() { }

        public Conta(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
    }
}
