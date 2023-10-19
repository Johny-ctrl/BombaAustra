using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BombaAustra.API.Migrations
{
    /// <inheritdoc />
    public partial class innerBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPANIAS",
                columns: table => new
                {
                    ID_COMPAÑIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANIAS", x => x.ID_COMPAÑIA);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPOS",
                columns: table => new
                {
                    ID_EQUIPO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPOS", x => x.ID_EQUIPO);
                });

            migrationBuilder.CreateTable(
                name: "ESTADO_EQUIPO",
                columns: table => new
                {
                    ID_ESTADO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO_EQUIPO", x => x.ID_ESTADO);
                });

            migrationBuilder.CreateTable(
                name: "NOMBRE_COMPANIAS",
                columns: table => new
                {
                    ID_NOMBRE_COMPAÑIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOMBRE_COMPANIAS", x => x.ID_NOMBRE_COMPAÑIA);
                });

            migrationBuilder.CreateTable(
                name: "REPORTES",
                columns: table => new
                {
                    ID_REPORTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORTES", x => x.ID_REPORTE);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_EQUIPO",
                columns: table => new
                {
                    ID_TIPO_EQUIPO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_EQUIPO", x => x.ID_TIPO_EQUIPO);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_USUARIOS",
                columns: table => new
                {
                    ID_TIPO_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_USUARIOS", x => x.ID_TIPO_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID_RUT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DV_RUT = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APELLIDO_P = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APELLIDO_M = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIPO_USUARIOS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID_RUT);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMPANIAS_ID_COMPAÑIA",
                table: "COMPANIAS",
                column: "ID_COMPAÑIA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPOS_ID_EQUIPO",
                table: "EQUIPOS",
                column: "ID_EQUIPO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ESTADO_EQUIPO_ID_ESTADO",
                table: "ESTADO_EQUIPO",
                column: "ID_ESTADO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NOMBRE_COMPANIAS_ID_NOMBRE_COMPAÑIA",
                table: "NOMBRE_COMPANIAS",
                column: "ID_NOMBRE_COMPAÑIA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REPORTES_ID_REPORTE",
                table: "REPORTES",
                column: "ID_REPORTE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TIPO_EQUIPO_ID_TIPO_EQUIPO",
                table: "TIPO_EQUIPO",
                column: "ID_TIPO_EQUIPO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TIPO_USUARIOS_ID_TIPO_USUARIO",
                table: "TIPO_USUARIOS",
                column: "ID_TIPO_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ID_RUT",
                table: "USUARIOS",
                column: "ID_RUT",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPANIAS");

            migrationBuilder.DropTable(
                name: "EQUIPOS");

            migrationBuilder.DropTable(
                name: "ESTADO_EQUIPO");

            migrationBuilder.DropTable(
                name: "NOMBRE_COMPANIAS");

            migrationBuilder.DropTable(
                name: "REPORTES");

            migrationBuilder.DropTable(
                name: "TIPO_EQUIPO");

            migrationBuilder.DropTable(
                name: "TIPO_USUARIOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
