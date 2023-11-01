using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BombaAustra.API.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_RUT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DV_RUT = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APELLIDO_P = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APELLIDO_M = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usertype = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COMPANIAS",
                columns: table => new
                {
                    ID_COMPAÑIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NOMBRE_COMPANIA = table.Column<int>(type: "int", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO_EQUIPO = table.Column<int>(type: "int", nullable: false),
                    NOMBRE_EQUIPO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESTADO_EQUIPO = table.Column<int>(type: "int", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO_EQUIPO", x => x.ID_ESTADO);
                });

            migrationBuilder.CreateTable(
                name: "GASTOS",
                columns: table => new
                {
                    ID_GASTO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AÑO_ACTUAL = table.Column<int>(type: "int", nullable: false),
                    AÑO_PASADO = table.Column<int>(type: "int", nullable: false),
                    COSTO_REVISION_TEC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GASTOS", x => x.ID_GASTO);
                });

            migrationBuilder.CreateTable(
                name: "MODELO_VEHICULO",
                columns: table => new
                {
                    ID_MODELO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODELO_VEHICULO", x => x.ID_MODELO);
                });

            migrationBuilder.CreateTable(
                name: "NOMBRE_COMPANIAS",
                columns: table => new
                {
                    ID_NOMBRE_COMPAÑIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_COMPAÑIA = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_USUARIOS", x => x.ID_TIPO_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_VEHICULO",
                columns: table => new
                {
                    SIGLA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PATENTE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MARCA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ULTIMA_REVISION_TEC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_MODELO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_VEHICULO", x => x.SIGLA);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_GASTOS_ID_GASTO",
                table: "GASTOS",
                column: "ID_GASTO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MODELO_VEHICULO_ID_MODELO",
                table: "MODELO_VEHICULO",
                column: "ID_MODELO",
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
                name: "IX_TIPO_VEHICULO_SIGLA",
                table: "TIPO_VEHICULO",
                column: "SIGLA",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "COMPANIAS");

            migrationBuilder.DropTable(
                name: "EQUIPOS");

            migrationBuilder.DropTable(
                name: "ESTADO_EQUIPO");

            migrationBuilder.DropTable(
                name: "GASTOS");

            migrationBuilder.DropTable(
                name: "MODELO_VEHICULO");

            migrationBuilder.DropTable(
                name: "NOMBRE_COMPANIAS");

            migrationBuilder.DropTable(
                name: "REPORTES");

            migrationBuilder.DropTable(
                name: "TIPO_EQUIPO");

            migrationBuilder.DropTable(
                name: "TIPO_USUARIOS");

            migrationBuilder.DropTable(
                name: "TIPO_VEHICULO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
