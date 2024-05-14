using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.TechChallenge.Fase1.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contato",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ddd = table.Column<int>(type: "INT", nullable: false),
                    telefone = table.Column<string>(type: "VARCHAR(9)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    excluido = table.Column<bool>(type: "BOOL", nullable: false),
                    dt_registro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    dt_alteracao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    dt_exclusao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regiao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ddd = table.Column<int>(type: "INT", nullable: false),
                    estado = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    regiao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    excluido = table.Column<bool>(type: "BOOL", nullable: false),
                    dt_registro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    dt_alteracao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    dt_exclusao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regiao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    role = table.Column<string>(type: "VARCHAR(5)", nullable: false),
                    excluido = table.Column<bool>(type: "BOOL", nullable: false),
                    dt_registro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    dt_alteracao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    dt_exclusao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contato");

            migrationBuilder.DropTable(
                name: "regiao");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
