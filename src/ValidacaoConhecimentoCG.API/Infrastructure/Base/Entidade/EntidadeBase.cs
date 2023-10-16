using System.ComponentModel.DataAnnotations.Schema;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Base.Entidade
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Column(Order = 98)]
        public DateTime DataCriacao { get; set; }

        [Column(Order = 99)]
        public DateTime? DataAtualizacao { get; set; }
    }
}
