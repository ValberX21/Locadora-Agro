namespace LocadoraAgro.Models
{
    public class FilmeModel
    {
        [Key]
        public int FilmeId { get; set; }
        public string Nome { get; set; } = "";
        public int Quantidade { get; set; } = 0;
        public string Genero { get; set; } = "";

        [NotMapped]
        public List<FilmeModel> Filmes { get; set; } = new List<FilmeModel>();
    }
}
