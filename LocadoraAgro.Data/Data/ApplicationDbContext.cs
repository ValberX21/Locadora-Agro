namespace Locadora.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<FilmeModel> Filmes { get; set; }        
        public DbSet<ViewLocacao> Locacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmeModel>().HasData(
                new FilmeModel { FilmeId = 1, Nome = "Inception", Quantidade = 10, Genero = "Sci-Fi" },
                new FilmeModel { FilmeId = 2, Nome = "The Dark Knight", Quantidade = 15, Genero = "Action" },
                new FilmeModel { FilmeId = 3, Nome = "Interstellar", Quantidade = 5, Genero = "Sci-Fi" },
                new FilmeModel { FilmeId = 4, Nome = "The Matrix", Quantidade = 8, Genero = "Sci-Fi" },
                new FilmeModel { FilmeId = 5, Nome = "Titanic", Quantidade = 20, Genero = "Romance" },
                new FilmeModel { FilmeId = 6, Nome = "Forrest Gump", Quantidade = 12, Genero = "Drama" },
                new FilmeModel { FilmeId = 7, Nome = "The Shawshank Redemption", Quantidade = 10, Genero = "Drama" },
                new FilmeModel { FilmeId = 8, Nome = "The Godfather", Quantidade = 7, Genero = "Crime" },
                new FilmeModel { FilmeId = 9, Nome = "Pulp Fiction", Quantidade = 8, Genero = "Crime" },
                new FilmeModel { FilmeId = 10, Nome = "Avatar", Quantidade = 18, Genero = "Sci-Fi" },
                new FilmeModel { FilmeId = 11, Nome = "Gladiator", Quantidade = 9, Genero = "Action" },
                new FilmeModel { FilmeId = 12, Nome = "The Lion King", Quantidade = 20, Genero = "Animation" },
                new FilmeModel { FilmeId = 13, Nome = "Finding Nemo", Quantidade = 15, Genero = "Animation" },
                new FilmeModel { FilmeId = 14, Nome = "Frozen", Quantidade = 25, Genero = "Animation" },
                new FilmeModel { FilmeId = 15, Nome = "Star Wars: A New Hope", Quantidade = 10, Genero = "Sci-Fi" },
                new FilmeModel { FilmeId = 16, Nome = "The Avengers", Quantidade = 22, Genero = "Action" },
                new FilmeModel { FilmeId = 17, Nome = "Black Panther", Quantidade = 14, Genero = "Action" },
                new FilmeModel { FilmeId = 18, Nome = "Joker", Quantidade = 0, Genero = "Drama" },
                new FilmeModel { FilmeId = 19, Nome = "Toy Story", Quantidade = 19, Genero = "Animation" },
                new FilmeModel { FilmeId = 20, Nome = "The Lord of the Rings: The Fellowship of the Ring", Quantidade = 10, Genero = "Fantasy" }
            );

            base.OnModelCreating(modelBuilder);

            var adminPasswordHash = HashPassword("admin");

            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                UserId = 1, 
                FullName = "admin",
                Password = adminPasswordHash,
                Email = "admin@firstpalace.com"
            });
        }

        public byte[] HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                return sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
