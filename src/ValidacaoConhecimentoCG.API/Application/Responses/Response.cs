using Newtonsoft.Json;

namespace ValidacaoConhecimentoCG.API.Application.Responses
{
    public class Response<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public T? Data { get; set; }

        [JsonProperty("errors")]
        public string[]? Erros { get; set; }
    }
}
