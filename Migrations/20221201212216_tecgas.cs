using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEM.Migrations
{
    public partial class tecgas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cli_Clientes",
                columns: table => new
                {
                    CodigoClienteId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cli_Nome = table.Column<string>(nullable: true),
                    Cli_CNPJ = table.Column<string>(nullable: true),
                    Cli_Endereco = table.Column<string>(nullable: true),
                    Cli_Telefone = table.Column<string>(nullable: true),
                    Cli_Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cli_Clientes", x => x.CodigoClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Usu_Usuarios",
                columns: table => new
                {
                    Usu_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Usu_Nome = table.Column<string>(nullable: true),
                    Usu_Email = table.Column<string>(nullable: true),
                    Usu_Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usu_Usuarios", x => x.Usu_Id);
                });

            migrationBuilder.CreateTable(
                name: "Ord_OrdemServicos",
                columns: table => new
                {
                    Ord_OrdemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ord_NumeroOrdem = table.Column<int>(nullable: false),
                    Ord_DataAbertura = table.Column<DateTime>(nullable: false),
                    CodigoClienteId = table.Column<int>(nullable: false),
                    ClienteCodigoClienteId = table.Column<int>(nullable: true),
                    Ord_Modelo = table.Column<string>(nullable: true),
                    Ord_Detalhes = table.Column<string>(nullable: true),
                    Ord_Diagnostico = table.Column<string>(nullable: true),
                    Ord_Solucao = table.Column<string>(nullable: true),
                    Ord_PecasTrocadas = table.Column<string>(nullable: true),
                    Ord_ValorServico = table.Column<string>(nullable: true),
                    Ord_ValorPeca = table.Column<string>(nullable: true),
                    Ord_ValorTotal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ord_OrdemServicos", x => x.Ord_OrdemId);
                    table.ForeignKey(
                        name: "FK_Ord_OrdemServicos_Cli_Clientes_ClienteCodigoClienteId",
                        column: x => x.ClienteCodigoClienteId,
                        principalTable: "Cli_Clientes",
                        principalColumn: "CodigoClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ord_OrdemServicos_ClienteCodigoClienteId",
                table: "Ord_OrdemServicos",
                column: "ClienteCodigoClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ord_OrdemServicos");

            migrationBuilder.DropTable(
                name: "Usu_Usuarios");

            migrationBuilder.DropTable(
                name: "Cli_Clientes");
        }
    }
}
