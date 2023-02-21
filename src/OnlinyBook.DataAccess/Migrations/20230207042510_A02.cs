using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinyBook.DataAccess.Migrations
{
	public partial class A02 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_OrderDetails_Products_ProductId",
				table: "OrderDetails");

			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Operators_OperatorId",
				table: "Orders");

			migrationBuilder.DropIndex(
				name: "IX_OrderDetails_ProductId",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "Price",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "ProductId",
				table: "OrderDetails");

			migrationBuilder.RenameColumn(
				name: "OperatorId",
				table: "Orders",
				newName: "ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_Orders_OperatorId",
				table: "Orders",
				newName: "IX_Orders_ProductId");

			migrationBuilder.UpdateData(
				table: "Administators",
				keyColumn: "Id",
				keyValue: 1L,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2023, 2, 7, 4, 25, 10, 6, DateTimeKind.Utc).AddTicks(217), new DateTime(2023, 2, 7, 4, 25, 10, 6, DateTimeKind.Utc).AddTicks(221) });

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Products_ProductId",
				table: "Orders",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Products_ProductId",
				table: "Orders");

			migrationBuilder.RenameColumn(
				name: "ProductId",
				table: "Orders",
				newName: "OperatorId");

			migrationBuilder.RenameIndex(
				name: "IX_Orders_ProductId",
				table: "Orders",
				newName: "IX_Orders_OperatorId");

			migrationBuilder.AddColumn<double>(
				name: "Price",
				table: "OrderDetails",
				type: "double precision",
				nullable: false,
				defaultValue: 0.0);

			migrationBuilder.AddColumn<long>(
				name: "ProductId",
				table: "OrderDetails",
				type: "bigint",
				nullable: false,
				defaultValue: 0L);

			migrationBuilder.UpdateData(
				table: "Administators",
				keyColumn: "Id",
				keyValue: 1L,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2023, 2, 6, 12, 56, 51, 754, DateTimeKind.Utc).AddTicks(4987), new DateTime(2023, 2, 6, 12, 56, 51, 754, DateTimeKind.Utc).AddTicks(4990) });

			migrationBuilder.CreateIndex(
				name: "IX_OrderDetails_ProductId",
				table: "OrderDetails",
				column: "ProductId");

			migrationBuilder.AddForeignKey(
				name: "FK_OrderDetails_Products_ProductId",
				table: "OrderDetails",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Operators_OperatorId",
				table: "Orders",
				column: "OperatorId",
				principalTable: "Operators",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
