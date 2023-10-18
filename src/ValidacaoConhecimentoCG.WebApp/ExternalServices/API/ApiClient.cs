using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;
using ValidacaoConhecimentoCG.WebApp.Configurations;
using ValidacaoConhecimentoCG.WebApp.ExternalServices.API.Response;
using ValidacaoConhecimentoCG.WebApp.Models;

namespace ValidacaoConhecimentoCG.WebApp.ExternalServices.API
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ConfiguracoesAPI _configuracoesAPI;

        public ApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _configuracoesAPI = _configuration.GetSection("ConfiguracoesAPI").Get<ConfiguracoesAPI>();
            _httpClient.BaseAddress = new Uri(_configuracoesAPI.UrlBase);
        }

        public async Task<Guid?> AdicionarConta(ContaViewModel conta)
        {
            var requisicao = JsonConvert.SerializeObject(conta);
            var stringContent = new StringContent(requisicao, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _httpClient.PostAsync(_configuracoesAPI.EndpointConta, stringContent);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return null;

            var retorno = JsonConvert.DeserializeObject<Response<Guid>>(content);
            if (retorno?.Sucess == null)
                return null;

            return retorno.Data;
        }

        public async Task<bool?> AtualizarConta(ContaViewModel conta)
        {
            var requisicao = JsonConvert.SerializeObject(conta);
            var stringContent = new StringContent(requisicao, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _httpClient.PutAsync(_configuracoesAPI.EndpointConta, stringContent);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return null;

            var retorno = JsonConvert.DeserializeObject<Response<bool>>(content);
            if (retorno?.Sucess == null)
                return null;

            return retorno.Data;
        }

        public async Task<bool?> RemoverConta(Guid id)
        {
            var endpoint = string.Format("{0}/{1}", _configuracoesAPI.EndpointConta, id);

            var response = await _httpClient.DeleteAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return null;

            var retorno = JsonConvert.DeserializeObject<Response<bool>>(content);
            if (retorno?.Sucess == null)
                return null;

            return retorno.Data;
        }

        public async Task<ContaViewModel?> ObterContaPorId(Guid id)
        {
            var endpoint = string.Format("{0}/{1}", _configuracoesAPI.EndpointConta, id);

            var response = await _httpClient.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return null;

            var retorno = JsonConvert.DeserializeObject<Response<ContaViewModel>>(content);
            if (retorno?.Sucess == null)
                return null;

            return retorno.Data;
        }

        public async Task<PaginacaoResponse<ContaViewModel>?> ObterContas()
        {
            var endpoint = _configuracoesAPI.EndpointConta + "?TamanhoDaPagina=0&NumeroDaPagina=0";

            var response = await _httpClient.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return null;

            var retorno = JsonConvert.DeserializeObject<Response<PaginacaoResponse<ContaViewModel>>>(content);
            if (retorno?.Sucess == null)
                return null;

            return retorno.Data;
        }

        public async Task<EnderecoResponse?> ObterEnderecoPorCep(string cep)
        {
            var endpoint = string.Format("{0}?cep={1}", _configuracoesAPI.EndpointCep, cep);

            var response = await _httpClient.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return null;

            var retorno = JsonConvert.DeserializeObject<Response<EnderecoResponse>>(content);
            if (retorno?.Sucess == null)
                return null;

            return retorno.Data;
        }
    }
}
