using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logic.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaPromociones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promociones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuerpoMensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AsuntoMensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destinatarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promociones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promociones_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promociones_EmpresaId",
                table: "Promociones",
                column: "EmpresaId");


            string ruta = AppDomain.CurrentDomain.BaseDirectory;
            string script = File.ReadAllText(Path.Combine(ruta, "Datos de Prueba", "Script-DatosPrueba.sql"));
            migrationBuilder.Sql(script);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promociones");
        }
    }
}
