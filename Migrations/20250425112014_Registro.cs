using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoMensalidade2.Migrations
{
    /// <inheritdoc />
    public partial class Registro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroEntradaSaida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroEntradaSaida", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroEntradaSaida");
        }
    }
}
