using Microsoft.EntityFrameworkCore;
using ValidacaoConhecimentoCG.API.Domain.Entidades;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.UoW;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Data.Context
{
    public class ValidacaoConhecimentoDBContext : DbContext, IUnitOfWork
    {
        private const string ConnectionStringKey = "DefaultConnection";

        private readonly IConfiguration _configuration;

        public ValidacaoConhecimentoDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Conta> Conta => Set<Conta>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString(ConnectionStringKey));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ValidacaoConhecimentoDBContext).Assembly);
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = new())
        {
            PreencherPropriedadesDeAuditoria();

            var sucesso = await SaveChangesAsync(cancellationToken) > 0;
            if (!sucesso)
                return false;

            return true;
        }

        private void PreencherPropriedadesDeAuditoria()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State is EntityState.Added)
                {
                    PreencherDataCriacao(entry);
                }
                else if (entry.State is EntityState.Modified)
                {
                    PreencherDataAlteracao(entry);
                }
            }
        }

        private static void PreencherDataCriacao(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
        {
            if (entry.Entity.GetType().GetProperty("DataCriacao") != null)
                entry.Property("DataCriacao").CurrentValue = DateTime.Now;
        }

        private static void PreencherDataAlteracao(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
        {
            if (entry.Entity.GetType().GetProperty("DataAlteracao") != null)
                entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
        }
    }
}
