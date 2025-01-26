namespace LocadoraAgro.Models.ViewModel
{
    public class ViewLocacao
    {
        [Key]
        public int idLocacao { get; set; }
        public string Filme { get; set; } = "";
        public DateTime dataDevolucao { get; set; }
        public string Locatario { get; set; } = string.Empty;

        public bool Devolvido = false;

        [NotMapped]
        public List<ViewLocacao> Locacoes { get; set; }
        [NotMapped]
        public int FilmeQuantDisponivel { get; set; }

    }
}
