using ValidacaoConhecimentoCG.API.Application.AppService.Interface;
using ValidacaoConhecimentoCG.API.Application.Validators;
using ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP;
using ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP.Response;
using ValidacaoConhecimentoCG.API.Infrastructure.Notificacoes;

namespace ValidacaoConhecimentoCG.API.Application.AppService
{
    public class CepAppService : ICepAppService
    {
        private const int TAMANHO_CEP = 8;

        private readonly IViaCEPClient _viaCEPClient;
        private readonly INotificador _notificador;

        public CepAppService(IViaCEPClient viaCEPClient, INotificador notificador)
        {
            _viaCEPClient = viaCEPClient;
            _notificador = notificador;
        }

        public async Task<EnderecoViaCEPResponse?> ObterEndereceoPorCep(string? cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != TAMANHO_CEP)
            {
                _notificador.AdicionarNotificacao(MensagensValidacoes.CepInvalido);
                return null;
            }

            var enderecoResult = await _viaCEPClient.ObterEndereco(cep!);
            return enderecoResult;

        }
    }
}
