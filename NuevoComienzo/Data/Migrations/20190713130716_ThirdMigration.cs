using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NuevoComienzo.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.CreateTable(
                name: "Anotacion",
                columns: table => new
                {
                    AnotacionId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiagnosticoAprendizaje = table.Column<string>(nullable: true),
                    DiagnosticoPsicologico = table.Column<string>(nullable: true),
                    ObservacionesSupervisor = table.Column<string>(nullable: true),
                    Alergias = table.Column<string>(nullable: true),
                    Medicamentos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotacion", x => x.AnotacionId);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    ProvinciaId = table.Column<byte>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.ProvinciaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificador",
                columns: table => new
                {
                    TipoIdentificadorID = table.Column<byte>(nullable: false),
                    DescTipoIdentificador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificador", x => x.TipoIdentificadorID);
                });

            migrationBuilder.CreateTable(
                name: "TipoPersona",
                columns: table => new
                {
                    TipoPersonaId = table.Column<byte>(nullable: false),
                    DescTipoPersona = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersona", x => x.TipoPersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Canton",
                columns: table => new
                {
                    CantonId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    ProvinciaId = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canton", x => x.CantonId);
                    table.ForeignKey(
                        name: "FK_Canton_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Identificador",
                columns: table => new
                {
                    IdentificadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoIdentificadorId = table.Column<byte>(nullable: true),
                    DescIdentificador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identificador", x => x.IdentificadorId);
                    table.ForeignKey(
                        name: "FK_Identificador_TipoIdentificador_TipoIdentificadorId",
                        column: x => x.TipoIdentificadorId,
                        principalTable: "TipoIdentificador",
                        principalColumn: "TipoIdentificadorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    DistritoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    CantonId = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.DistritoId);
                    table.ForeignKey(
                        name: "FK_Distrito_Canton_CantonId",
                        column: x => x.CantonId,
                        principalTable: "Canton",
                        principalColumn: "CantonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    DireccionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescDireccion = table.Column<string>(nullable: true),
                    DistritoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.DireccionId);
                    table.ForeignKey(
                        name: "FK_Direccion_Distrito_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "DistritoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaId = table.Column<Guid>(nullable: false),
                    TipoPersonaId = table.Column<byte>(nullable: false),
                    IdentificadorId = table.Column<int>(nullable: false),
                    DireccionId = table.Column<int>(nullable: false),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    Sexo = table.Column<bool>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    AnotacionId = table.Column<short>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Persona_Anotacion_AnotacionId",
                        column: x => x.AnotacionId,
                        principalTable: "Anotacion",
                        principalColumn: "AnotacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "DireccionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Identificador_IdentificadorId",
                        column: x => x.IdentificadorId,
                        principalTable: "Identificador",
                        principalColumn: "IdentificadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_TipoPersona_TipoPersonaId",
                        column: x => x.TipoPersonaId,
                        principalTable: "TipoPersona",
                        principalColumn: "TipoPersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canton_ProvinciaId",
                table: "Canton",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_DistritoId",
                table: "Direccion",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Distrito_CantonId",
                table: "Distrito",
                column: "CantonId");

            migrationBuilder.CreateIndex(
                name: "IX_Identificador_TipoIdentificadorId",
                table: "Identificador",
                column: "TipoIdentificadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_AnotacionId",
                table: "Persona",
                column: "AnotacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_DireccionId",
                table: "Persona",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdentificadorId",
                table: "Persona",
                column: "IdentificadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TipoPersonaId",
                table: "Persona",
                column: "TipoPersonaId");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Anotacion");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Identificador");

            migrationBuilder.DropTable(
                name: "TipoPersona");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "TipoIdentificador");

            migrationBuilder.DropTable(
                name: "Canton");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
