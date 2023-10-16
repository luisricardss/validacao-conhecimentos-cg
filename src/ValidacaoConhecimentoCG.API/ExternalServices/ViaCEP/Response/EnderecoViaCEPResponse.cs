using Newtonsoft.Json;

namespace ValidacaoConhecimentoCG.API.ExternalServices.ViaCEP.Response
{
    public class EnderecoViaCEPResponse
    {
        [JsonProperty("cep")]
        public string? CEP { get; set; }

        [JsonProperty("logradouro")]
        public string? Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string? Complemento { get; set; }

        [JsonProperty("bairro")]
        public string? Bairro { get; set; }

        [JsonProperty("localidade")]
        public string? Cidade { get; set; }

        [JsonProperty("uf")]
        public string? UF { get; set; }

        [JsonProperty("ibge")]
        public string? IBGE { get; set; }

        [JsonProperty("gia")]
        public string? GIA { get; set; }

        [JsonProperty("ddd")]
        public string? DDD { get; set; }

        [JsonProperty("siafi")]
        public string? SIAFI { get; set; }
    }
}
