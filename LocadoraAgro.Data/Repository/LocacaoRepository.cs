namespace LocadoraAgro.Data.Repository
{
    public class LocacaoRepository
    {
        private readonly ApplicationDbContext _db;

        public LocacaoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool alugaFilme(ViewLocacao locacao)
        {
            try
            {
                //Cria registro de locação
                _db.Locacao.Add(locacao);

                FilmeModel baixaEstoqueFilme = _db.Filmes.Where(F => F.Nome == locacao.Filme).FirstOrDefault();

                baixaEstoqueFilme.Quantidade--;

                _db.Filmes.Update(baixaEstoqueFilme);

                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ViewLocacao> listarLocacoes()
        {
            List<ViewLocacao> listFilmesAlugados = new List<ViewLocacao>();

            try
            {
                listFilmesAlugados = _db.Locacao.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listFilmesAlugados;
        }

        public List<FilmeRelatorio> relatorioFilmes()
        {
            return (from filme in _db.Filmes
                    join locacao in _db.Locacao on filme.Nome equals locacao.Filme
                    select new FilmeRelatorio
                    {
                        NomeFilme = filme.Nome,
                        QuantidadeDisponivel = filme.Quantidade,
                        QuantidadeLocacoes = _db.Locacao.Count(l => l.Filme == filme.Nome)
                    })
                    .Distinct()
                    .ToList();
        }
    }
}
