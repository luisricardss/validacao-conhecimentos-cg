using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValidacaoConhecimentoCG.API.Domain.Entidades;
using ValidacaoConhecimentoCG.API.Infrastructure.Utils;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Mapping
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable(Constantes.Tabelas.Conta, Constantes.Schemas.Sistema);
        }
    }
}
