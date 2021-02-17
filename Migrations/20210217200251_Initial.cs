using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    PK_Estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.PK_Estado);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    PK_Funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Estado = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.PK_Funcionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_Estado_FK_Estado",
                        column: x => x.FK_Estado,
                        principalTable: "Estado",
                        principalColumn: "PK_Estado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estado_Sigla",
                table: "Estado",
                column: "Sigla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_FK_Estado",
                table: "Funcionario",
                column: "FK_Estado",
                unique: false,
                filter: "[FK_Estado] IS NOT NULL");

            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('AC', 'Acre');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('AL', 'Alagoas');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('AP', 'Amapá');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('AM', 'Amazonas');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('BA', 'Bahia');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('CE', 'Ceará');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('DF', 'Distrito Federal');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('ES', 'Espírito Santo');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('GO', 'Goiás');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('MA', 'Maranhão');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('MT', 'Mato Grosso');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('MS', 'Mato Grosso do Sul');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('MG', 'Minas Gerais');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('PA', 'Pará');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('PB', 'Paraíba');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('PR', 'Paraná');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('PE', 'Pernambuco');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('PI', 'Piauí');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('RJ', 'Rio de Janeiro');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('RN', 'Rio Grande do Norte');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('RS', 'Rio Grande do Sul');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('RO', 'Rondônia');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('RR', 'Roraima');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('SC', 'Santa Catarina');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('SP', 'São Paulo');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('SE', 'Sergipe');");
            migrationBuilder.Sql("INSERT INTO Estado (Sigla, Nome) VALUES ('TO', 'Tocantins')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
