using Microsoft.AspNetCore.Mvc;
using RadioDJLocal.Data;
using RadioDJLocal.Models;
using System.Diagnostics;

namespace RadioDJLocal.Controllers
{
    public class HomeController : Controller
    {
        private readonly RadioDjRepository _repository;
        private readonly SongRepository _songRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly SubcategoryRepository _subcategoryRepository;
        private readonly GenreRepository _genreRepository;


        public HomeController(
            RadioDjRepository repository,
            SongRepository songRepository,
            CategoryRepository categoryRepository,
            SubcategoryRepository subcategoryRepository,
            GenreRepository genreRepository)
        {
            _repository = repository;
            _songRepository = songRepository;
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _genreRepository = genreRepository;
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

        //public async Task<IActionResult> TestarFiltros()
        //{
        //    var filtro = new SongFiltro
        //    {
        //        Artist = "aline"
        //    };

        //    var musicas = await _songRepository.ListarFiltradasAsync(filtro);

        //    return View("Musicas", musicas);
        //}

        //public async Task<IActionResult> TestarFiltros()
        //{
        //    var musicas = await _songRepository.ListarAsync();

        //    ViewBag.Categorias = await _categoryRepository.ListarAsync();
        //    ViewBag.Subcategorias = await _subcategoryRepository.ListarAsync();
        //    ViewBag.Generos = await _genreRepository.ListarAsync();
        //    ViewBag.TiposFaixa = TrackType.GetLista();

        //    return View("Musicas", musicas);
        //}

        public async Task<IActionResult> TestarFiltros()
        {
            await CarregarListasFiltrosAsync();

            var filtro = new SongFiltro
            {
                Artist = "aline"
            };

            var musicas = await _songRepository.ListarFiltradasAsync(filtro);

            return View("Musicas", musicas);
        }

        /// <summary>
        /// Pesquisa as músicas através dos campos do formulário .
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> PesquisarMusicas(
            [FromQuery] SongFiltro filtro)
        {
            await CarregarListasFiltrosAsync();

            var musicas = await _songRepository.ListarFiltradasAsync(filtro);

            ViewBag.Filtro = filtro;

            return View("Musicas", musicas);
        }

        /// <summary>
        /// Retorna os dados de uma música pelo identificador informado.
        /// </summary>
        /// <param name="id">Identificador único da música.</param>
        /// <returns>Um objeto JSON com os dados da música encontrada ou um status NotFound se não existir.</returns>
        /// <![CDATA[24/10/2026]]>
        [HttpGet]
        public async Task<IActionResult> BuscarMusica(int id)
        {
            var musica = await _songRepository.BuscarPorIdAsync(id);

            if (musica == null)
            {
                return NotFound();
            }

            return Json(musica);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
                
        private async Task CarregarListasFiltrosAsync()
        {
            ViewBag.Categorias = await _categoryRepository.ListarAsync();
            ViewBag.Subcategorias = await _subcategoryRepository.ListarAsync();
            ViewBag.Generos = await _genreRepository.ListarAsync();
            ViewBag.TiposFaixa = TrackType.GetLista();
        }

        public async Task<IActionResult> Musicas()
        {
            await CarregarListasFiltrosAsync();

            var musicas = await _songRepository.ListarAsync();

            return View(musicas);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
