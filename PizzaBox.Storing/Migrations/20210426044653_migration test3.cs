using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migrationtest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderID",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaComponent");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StoreID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerEntityID1",
                table: "Orders",
                newName: "StoreEntityID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerEntityID1",
                table: "Orders",
                newName: "IX_Orders_StoreEntityID");

            migrationBuilder.AddColumn<long>(
                name: "OrderEntityID",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityID",
                table: "Pizzas",
                column: "OrderEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders",
                column: "StoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderEntityID",
                table: "Pizzas",
                column: "OrderEntityID",
                principalTable: "Orders",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "OrderEntityID",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "StoreEntityID",
                table: "Orders",
                newName: "CustomerEntityID1");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StoreEntityID",
                table: "Orders",
                newName: "IX_Orders_CustomerEntityID1");

            migrationBuilder.AddColumn<long>(
                name: "OrderID",
                table: "Pizzas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StoreID",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "PizzaComponent",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaComponent", x => x.EntityID);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "EntityID",
                keyValue: 1L,
                column: "StoreID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "EntityID",
                keyValue: 1L,
                column: "OrderID",
                value: 1L);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderID",
                table: "Pizzas",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreID",
                table: "Orders",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID1",
                table: "Orders",
                column: "CustomerEntityID1",
                principalTable: "Customers",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreID",
                table: "Orders",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderID",
                table: "Pizzas",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
