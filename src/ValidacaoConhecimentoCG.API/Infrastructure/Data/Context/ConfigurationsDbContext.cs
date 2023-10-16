using Microsoft.EntityFrameworkCore;

namespace ValidacaoConhecimentoCG.API.Infrastructure.Data.Context
{
    public class ConfigurationsDbContext
    {
        private readonly ValidacaoConhecimentoDBContext _dbContext;

        public ConfigurationsDbContext(ValidacaoConhecimentoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Migrate()
        {
            _dbContext.Database.Migrate();
            _dbContext.SaveChanges();
            SeedData();
        }

        public void SeedData()
        {
            if (_dbContext.Conta.Any())
                return;

            //SeedBaseInicial();
        }

        private void SeedBaseInicial()
        {
            using var tran = _dbContext.Database.BeginTransaction();

            try
            {
                _dbContext.SaveChanges();
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
        }
    }
}
