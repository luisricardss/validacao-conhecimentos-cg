namespace ValidacaoConhecimentoCG.WebApp.ExternalServices.API.Response
{
    public class Response<T>
    {
        public bool Sucess { get; set; }
        public T? Data { get; set; }
    }
}
