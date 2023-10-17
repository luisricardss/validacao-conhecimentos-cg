using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidacaoConhecimentoCG.WebApp.ExternalServices.API;
using ValidacaoConhecimentoCG.WebApp.Models;

namespace ValidacaoConhecimentoCG.WebApp.Controllers
{
    public class ContaController : Controller
    {
        private readonly ILogger<ContaController> _logger;
        private readonly IApiClient _apiClient;

        public ContaController(ILogger<ContaController> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var contas = new ContasViewModel();

            var contasResponse = await _apiClient.ObterContas();
            if (contasResponse != null)
                contas.Contas.AddRange(contasResponse.Itens);

            return View(contas);
        }

        public async Task<IActionResult> Form(Guid? id)
        {
            if (id.HasValue)
            {
                var contaResponse = await _apiClient.ObterContaPorId(id.Value);
                if (contaResponse != null)
                    return View("Form", contaResponse);
            }

            var conta = new ContaViewModel();
            return View("Form", conta);
        }

        [HttpPost]
        public async Task<IActionResult> Form(ContaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id.HasValue)
                {
                    var result = await _apiClient.AtualizarConta(model);
                    if (result == null)
                    {
                        TempData["Erro"] = "Ocorreu um erro inesperado.";
                        return View(model);
                    }
                }
                else
                {
                    var result = await _apiClient.AdicionarConta(model);
                    if (result == null)
                    {
                        TempData["Erro"] = "Ocorreu um erro inesperado.";
                        return View(model);
                    }
                }

                TempData["Sucesso"] = "Conta salva com sucesso.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Excluir(Guid? id)
        {
            if (id.HasValue)
            {
                var contaResponse = await _apiClient.RemoverConta(id.Value);
                if (contaResponse == null || !contaResponse.Value)
                {
                    TempData["Erro"] = "Ocorreu um erro inesperado.";
                }
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}