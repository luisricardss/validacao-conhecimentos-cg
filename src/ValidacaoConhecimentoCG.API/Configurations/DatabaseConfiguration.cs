using Microsoft.EntityFrameworkCore;
using ValidacaoConhecimentoCG.API.Infrastructure.Data.Context;

namespace ValidacaoConhecimentoCG.API.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void RegisterApiDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ValidacaoConhecimentoDBContext>(options => options.UseSqlServer());
            services.AddScoped<ConfigurationsDbContext>();
        }
    }
}
