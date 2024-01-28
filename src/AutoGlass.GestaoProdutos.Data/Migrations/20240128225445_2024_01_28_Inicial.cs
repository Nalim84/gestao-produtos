using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoGlass.GestaoProdutos.Data.Migrations
{
    public partial class _2024_01_28_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime", nullable: false),
                    CodigoFornecedor = table.Column<int>(type: "int", nullable: true),
                    DescricaoFornecedor = table.Column<string>(type: "varchar(300)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
