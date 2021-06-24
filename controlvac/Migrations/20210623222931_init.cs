using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace controlvac.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Fabricante = table.Column<string>(type: "TEXT", nullable: false),
                    Lote = table.Column<string>(type: "TEXT", nullable: true),
                    Validade = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Doses = table.Column<int>(type: "INTEGER", nullable: false),
                    Intervalo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacinacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    VacinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Dose = table.Column<int>(type: "INTEGER", nullable: false),
                    DosesTomadas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacinacoes_Vacinas_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Sus = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Cep = table.Column<string>(type: "TEXT", nullable: true),
                    Municipio = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    VacinacaoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Vacinacoes_VacinacaoId",
                        column: x => x.VacinacaoId,
                        principalTable: "Vacinacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_VacinacaoId",
                table: "Pacientes",
                column: "VacinacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacinacoes_PacienteId",
                table: "Vacinacoes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacinacoes_VacinaId",
                table: "Vacinacoes",
                column: "VacinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinacoes_Pacientes_PacienteId",
                table: "Vacinacoes",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Vacinacoes_VacinacaoId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "Vacinacoes");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Vacinas");
        }
    }
}
