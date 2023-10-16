using Newtonsoft.Json;
using ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP.Response;
using ValidacaoConhecimentoCG.API.Infrastructure.Extensions;

namespace ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP
{
    public class ViaCEPClient : IViaCEPClient
    {
        private const string UrlViaCEPKey = "ViaCEP:UrlGet";

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ViaCEPClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<EnderecoViaCEPResponse?> ObterEndereco(string cep)
        {
            var urlViaCEP = _configuration[UrlViaCEPKey];

            var response = await _httpClient.GetAsync(string.Format(urlViaCEP, cep.ApenasNumeros()));

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<EnderecoViaCEPResponse>(content);
                return result;
            }

            return new EnderecoViaCEPResponse();
        }
    }
}
