using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinyBook.DataAccess.Migrations
{
	public partial class A01 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_OrderComments_Operators_OperatorId",
				table: "OrderComments");

			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Delivers_ProductId",
				table: "Orders");

			migrationBuilder.DropIndex(
				name: "IX_Orders_ProductId",
				table: "Orders");

			migrationBuilder.DropIndex(
				name: "IX_OrderComments_OperatorId",
				table: "OrderComments");

			migrationBuilder.DropColumn(
				name: "ProductId",
				table: "Orders");

			migrationBuilder.DropColumn(
				name: "Amount",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "OperatorId",
				table: "OrderComments");

			migrationBuilder.UpdateData(
				table: "Administators",
				keyColumn: "Id",
				keyValue: 1L,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2023, 2, 6, 12, 56, 51, 754, DateTimeKind.Utc).AddTicks(4987), new DateTime(2023, 2, 6, 12, 56, 51, 754, DateTimeKind.Utc).AddTicks(4990) });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<long>(
				name: "ProductId",
				table: "Orders",
				type: "bigint",
				nullable: false,
				defaultValue: 0L);

			migrationBuilder.AddColumn<int>(
				name: "Amount",
				table: "OrderDetails",
				type: "integer",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<long>(
				name: "OperatorId",
				table: "OrderComments",
				type: "bigint",
				nullable: false,
				defaultValue: 0L);

			migrationBuilder.UpdateData(
				table: "Administators",
				keyColumn: "Id",
				keyValue: 1L,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2023, 2, 4, 18, 57, 5, 871, DateTimeKind.Utc).AddTicks(9841), new DateTime(2023, 2, 4, 18, 57, 5, 871, DateTimeKind.Utc).AddTicks(9843) });

			migrationBuilder.CreateIndex(
				name: "IX_Orders_ProductId",
				table: "Orders",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_OrderComments_OperatorId",
				table: "OrderComments",
				column: "OperatorId");

			migrationBuilder.AddForeignKey(
				name: "FK_OrderComments_Operators_OperatorId",
				table: "OrderComments",
				column: "OperatorId",
				principalTable: "Operators",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Delivers_ProductId",
				table: "Orders",
				column: "ProductId",
				principalTable: "Delivers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
