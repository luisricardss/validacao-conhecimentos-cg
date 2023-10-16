using Microsoft.AspNetCore.Mvc;
using ValidacaoConhecimentoCG.API.Infrastructure.Notificacoes;

namespace ValidacaoConhecimentoCG.API.Controllers.Base
{
    [ApiController]
    public class BaseController : Controller
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = ObterNotificacoes()
            });
        }

        protected ActionResult CustomError(string error)
        {
            NotificarErro(error);

            return CustomResponse();
        }


        protected bool OperacaoValida() => !_notificador.TemNotificacao();

        protected List<string> ObterNotificacoes()
        {
            var mensagens = _notificador
                .ObterNotificacoes()
                .Select(n => n.Mensagem)
                .ToList();

            return mensagens;
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.AdicionarNotificacao(new Notificacao(mensagem));
        }
    }
}
