using FluentValidation;
using ValidacaoConhecimentoCG.API.Application.Requests.Conta;

namespace ValidacaoConhecimentoCG.API.Application.Validators
{
    public class ContaRequestValidator : AbstractValidator<ContaRequest>
    {
        public ContaRequestValidator() 
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage(x => MensagensValidacoes.NomeObrigatorio)
                .NotEmpty()
                .WithMessage(x => MensagensValidacoes.NomeObrigatorio);

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage(x => MensagensValidacoes.DescricaoObrigatoria)
                .NotEmpty()
                .WithMessage(x => MensagensValidacoes.DescricaoObrigatoria);
        }
    }
}
