using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderedPizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedPizzas_Orders_OrderId",
                table: "OrderedPizzas");

            migrationBuilder.DropIndex(
                name: "IX_OrderedPizzas_OrderId",
                table: "OrderedPizzas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderedPizzas_OrderId",
                table: "OrderedPizzas",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedPizzas_Orders_OrderId",
                table: "OrderedPizzas",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
