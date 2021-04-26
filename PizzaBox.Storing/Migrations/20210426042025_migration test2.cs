using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migrationtest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "CustomerEntityID",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CustomerEntityID1",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "EntityID",
                keyValue: 1L,
                column: "Price",
                value: 5.00m);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEntityID",
                table: "Orders",
                column: "CustomerEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEntityID1",
                table: "Orders",
                column: "CustomerEntityID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID",
                table: "Orders",
                column: "CustomerEntityID",
                principalTable: "Customers",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID1",
                table: "Orders",
                column: "CustomerEntityID1",
                principalTable: "Customers",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerEntityID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerEntityID1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerEntityID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerEntityID1",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "CustomerID",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "EntityID",
                keyValue: 1L,
                column: "CustomerID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "EntityID",
                keyValue: 1L,
                column: "Price",
                value: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
