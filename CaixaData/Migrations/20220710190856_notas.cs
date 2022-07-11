using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CaixaData.Migrations
{
    public partial class notas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var data = DateTime.Now.ToString("yyyy-MM-dd");
           migrationBuilder.Sql(@$"INSERT INTO Notas(Valor, Quantidade, DataAtualizacao) Values(10, 0, '{ data }' )");
           migrationBuilder.Sql(@$"INSERT INTO Notas(Valor, Quantidade, DataAtualizacao) Values(20, 0, '{ data }' )");
           migrationBuilder.Sql(@$"INSERT INTO Notas(Valor, Quantidade, DataAtualizacao) Values(50, 0, '{ data }' )");
           migrationBuilder.Sql(@$"INSERT INTO Notas(Valor, Quantidade, DataAtualizacao) Values(100, 0, '{ data }' )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
