using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logic.Migrations
{
    /// <inheritdoc />
    public partial class cambioIndice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_ClienteId",
                table: "Favoritos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos",
                columns: new[] { "ClienteId", "ServicioId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos",
                columns: new[] { "Id", "ClienteId", "ServicioId" });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_ClienteId",
                table: "Favoritos",
                column: "ClienteId");
        }
    }
}
