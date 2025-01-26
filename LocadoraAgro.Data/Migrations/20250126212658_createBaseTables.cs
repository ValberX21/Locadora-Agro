using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocadoraAgro.Data.Migrations
{
    /// <inheritdoc />
    public partial class createBaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.FilmeId);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    idLocacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locatario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.idLocacao);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "FilmeId", "Genero", "Nome", "Quantidade" },
                values: new object[,]
                {
                    { 1, "Sci-Fi", "Inception", 10 },
                    { 2, "Action", "The Dark Knight", 15 },
                    { 3, "Sci-Fi", "Interstellar", 5 },
                    { 4, "Sci-Fi", "The Matrix", 8 },
                    { 5, "Romance", "Titanic", 20 },
                    { 6, "Drama", "Forrest Gump", 12 },
                    { 7, "Drama", "The Shawshank Redemption", 10 },
                    { 8, "Crime", "The Godfather", 7 },
                    { 9, "Crime", "Pulp Fiction", 8 },
                    { 10, "Sci-Fi", "Avatar", 18 },
                    { 11, "Action", "Gladiator", 9 },
                    { 12, "Animation", "The Lion King", 20 },
                    { 13, "Animation", "Finding Nemo", 15 },
                    { 14, "Animation", "Frozen", 25 },
                    { 15, "Sci-Fi", "Star Wars: A New Hope", 10 },
                    { 16, "Action", "The Avengers", 22 },
                    { 17, "Action", "Black Panther", 14 },
                    { 18, "Drama", "Joker", 0 },
                    { 19, "Animation", "Toy Story", 19 },
                    { 20, "Fantasy", "The Lord of the Rings: The Fellowship of the Ring", 10 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FullName", "Password" },
                values: new object[] { 1, "admin@firstpalace.com", "admin", new byte[] { 140, 105, 118, 229, 181, 65, 4, 21, 189, 233, 8, 189, 77, 238, 21, 223, 177, 103, 169, 200, 115, 252, 75, 184, 168, 31, 111, 42, 180, 72, 169, 24 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
