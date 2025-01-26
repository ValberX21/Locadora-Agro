using Locadora.Data.Data;

namespace Locadora.Data.Repository
{
    public class FilmesRepository
    {
        private readonly ApplicationDbContext _db;

        public FilmesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<FilmeModel> listarFilmes()
        {
            List<FilmeModel> listaFilmes = new List<FilmeModel>();

            try
            {
                listaFilmes = _db.Filmes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaFilmes;
        }

        public FilmeModel selecionaFilme(int FilmeId)
        {
            FilmeModel? filme = new FilmeModel();

            try
            {
                filme = _db.Filmes.Where(f => f.FilmeId == FilmeId).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar filme - " + ex.Message);
            }

            return filme;
        }

    }
}
