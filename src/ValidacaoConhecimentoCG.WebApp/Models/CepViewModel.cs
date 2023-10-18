using System.ComponentModel.DataAnnotations;
using ValidacaoConhecimentoCG.WebApp.ExternalServices.API.Response;

namespace ValidacaoConhecimentoCG.WebApp.Models
{
    public class CepViewModel
    {
        [Required(ErrorMessage = "O campo Cep é obrigatório.")]
        [StringLength(8, MinimumLength = 3, ErrorMessage = "O campo Cep deve ter 8 caracteres.")]
        public string Cep { get; set; } = string.Empty;

        public EnderecoResponse? Endereco { get; set; }
    }
}
