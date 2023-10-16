using FluentValidation.Results;
using ValidacaoConhecimentoCG.API.Application.Validators;

namespace ValidacaoConhecimentoCG.API.Application.Requests.Conta
{
    public class ContaRequest
    {
        private readonly ContaRequestValidator _validator;

        public ContaRequest()
        {
            _validator = new ContaRequestValidator();
        }

        //public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        public bool EhValido() => Validar().IsValid;
        public ValidationResult Validar() => _validator.Validate(this);
    }
}
