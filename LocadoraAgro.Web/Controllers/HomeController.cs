namespace LocadoraAgro.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilmesRepository _filmesRepository;
        private readonly LocacaoRepository _locacaoRepository;
        public HomeController(FilmesRepository filmesRepository, LocacaoRepository locacaoRepository)
        {
            _filmesRepository = filmesRepository;
            _locacaoRepository = locacaoRepository;
        }

        public IActionResult Index(FilmeModel filmeModel)
        {
            filmeModel.Filmes = listFilmes();
            return View("Index", filmeModel);
        }

        public List<FilmeModel> listFilmes()
        {
            return _filmesRepository.listarFilmes();
        }

        [Route("Home/AlugarFilme/{FilmeId:int}")]
        public IActionResult AlugarFilme(int FilmeId)
        {
            if (FilmeId == 0)
            {
                return BadRequest("Invalid FilmeId");
            }

            FilmeModel dtFilme = _filmesRepository.selecionaFilme(FilmeId);

            ViewLocacao viewLocacao = new ViewLocacao
            {
                Filme = dtFilme.Nome,
                dataDevolucao = DateTime.Today.AddDays(5)
            };

            return View("~/Views/Locacao/Index.cshtml", viewLocacao);
        }

        public IActionResult criaLocacao(ViewLocacao locacao)
        {
            try
            {
                bool alugado = _locacaoRepository.alugaFilme(locacao);
                TempData["success"] = "Locação feita com sucesso";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Erro ao fazer locação";
                throw new Exception(ex.Message);
            }

            //Carrega lista de filmes disponiveis para alugar
            FilmeModel filmeModel = new FilmeModel();
            filmeModel.Filmes = listFilmes();
            return View("~/Views/Home/Index.cshtml", filmeModel);
        }

        public IActionResult ADMPAGE(ViewLocacao locacoes)
        {
            List<ViewLocacao> ListaLocacoes = _locacaoRepository.listarLocacoes();

            locacoes.Locacoes = ListaLocacoes;

            return View("~/Views/Administrativo/Index.cshtml", locacoes);
        }

        public IActionResult geraExcel()
        {
            try
            {
                List<FilmeRelatorio> filmesRel = _locacaoRepository.relatorioFilmes();

                var csvBuilder = new StringBuilder();

                csvBuilder.AppendLine("Nome do filme,Unidades disponiveis,Unidades alugadas");

                foreach (var rental in filmesRel)
                {
                    csvBuilder.AppendLine($"{rental.NomeFilme},{rental.QuantidadeDisponivel},{rental.QuantidadeLocacoes}");
                }

                var csvBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());

                TempData["success"] = "Relatorio gerado com sucesso";

                return File(csvBytes, "text/csv", "RelatorioFilmes" + DateTime.UtcNow.ToString() + ".csv");

            }
            catch (Exception ex)
            {
                TempData["error"] = "Erro ao gerar relatorio";
                throw new Exception(ex.Message);
            }

        }
    }
}
