using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidacaoConhecimentoCG.WebApp.ExternalServices.API;
using ValidacaoConhecimentoCG.WebApp.Models;

namespace ValidacaoConhecimentoCG.WebApp.Controllers
{
    public class CepController : Controller
    {
        private readonly ILogger<CepController> _logger;
        private readonly IApiClient _apiClient;

        public CepController(ILogger<CepController> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuscarEndereco(CepViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiClient.ObterEnderecoPorCep(model.Cep);
                if (result == null)
                {
                    TempData["Erro"] = "Ocorreu um erro inesperado.";
                    return View(model);
                }

                model.Endereco = result;
                return View("Index", model);
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