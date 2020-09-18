using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai.EfCore.Migrations
{
    public partial class AlterTablePedidositens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItens_Produtos_IdPedido",
                table: "PedidosItens");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "PedidosItens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItens_IdProduto",
                table: "PedidosItens",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItens_Produtos_IdProduto",
                table: "PedidosItens",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItens_Produtos_IdProduto",
                table: "PedidosItens");

            migrationBuilder.DropIndex(
                name: "IX_PedidosItens_IdProduto",
                table: "PedidosItens");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "PedidosItens");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItens_Produtos_IdPedido",
                table: "PedidosItens",
                column: "IdPedido",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
