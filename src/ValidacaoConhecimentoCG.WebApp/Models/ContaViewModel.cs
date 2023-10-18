using System.ComponentModel.DataAnnotations;

namespace ValidacaoConhecimentoCG.WebApp.Models
{
    public class ContaViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e no máximo 20 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Descrição deve ter entre 3 e no máximo 100 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
    }
}