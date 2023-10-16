using ValidacaoConhecimentoCG.API.Application.AppService;
using ValidacaoConhecimentoCG.API.Application.AppService.Interface;
using ValidacaoConhecimentoCG.API.Domain.Repository;
using ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP;
using ValidacaoConhecimentoCG.API.Infrastructure.Data.Repository;
using ValidacaoConhecimentoCG.API.Infrastructure.Notificacoes;

namespace ValidacaoConhecimentoCG.API.Configurations
{
    public static class BootstrapperConfiguration
    {
        public static void RegisterServicesApi(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificador, Notificador>();
        }

        public static void RegisterRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IContaRepository, ContaRepository>();
        }

        public static void RegisterAppServices(this IServiceCollection services) 
        {
            services.AddScoped<IContaAppService, ContaAppService>();
            services.AddScoped<ICepAppService, CepAppService>();
        }

        public static void RegisterHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<IViaCEPClient, ViaCEPClient>();
        }

    }
}
