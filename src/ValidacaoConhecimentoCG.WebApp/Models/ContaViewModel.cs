using System.ComponentModel.DataAnnotations;

namespace ValidacaoConhecimentoCG.WebApp.Models
{
    public class ContaViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome � obrigat�rio.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e no m�ximo 20 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Descri��o � obrigat�rio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Descri��o deve ter entre 3 e no m�ximo 100 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
    }
}