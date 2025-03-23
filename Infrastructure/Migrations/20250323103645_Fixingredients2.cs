using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixingredients2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_OrderedPizzas_OrderedPizzaId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_OrderedPizzaId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OrderedPizzaId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int[]>(
                name: "AdditionalIngredientsIds",
                table: "OrderedPizzas",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalIngredientsIds",
                table: "OrderedPizzas");

            migrationBuilder.AddColumn<int>(
                name: "OrderedPizzaId",
                table: "Ingredients",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_OrderedPizzaId",
                table: "Ingredients",
                column: "OrderedPizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_OrderedPizzas_OrderedPizzaId",
                table: "Ingredients",
                column: "OrderedPizzaId",
                principalTable: "OrderedPizzas",
                principalColumn: "Id");
        }
    }
}
