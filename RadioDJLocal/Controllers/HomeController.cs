using Microsoft.AspNetCore.Mvc;
using RadioDJLocal.Data;
using RadioDJLocal.Models;
using System.Diagnostics;

namespace RadioDJLocal.Controllers
{
    public class HomeController : Controller
    {
        private readonly RadioDjRepository _repository;

        public HomeController(RadioDjRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> TestarBanco()
        {
            try
            {
                var resultado = await _repository.TestarConexaoAsync();

                ViewBag.Mensagem = resultado == 1
                    ? "Conexão com o MariaDB estabelecida com sucesso!"
                    : "A consulta retornou um resultado inesperado.";

                ViewBag.Sucesso = resultado == 1;
            }
            catch (Exception)
            {
                ViewBag.Mensagem =
                    "Não foi possível conectar ao banco. Verifique a configuração e os logs da aplicação.";

                ViewBag.Sucesso = false;
            }

            return View();
        }

        public async Task<IActionResult> Tabelas()
        {
            var tabelas = await _repository.ListarTabelasAsync();
            return View(tabelas);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
