using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinyBook.DataAccess.Migrations
{
	public partial class A03 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_OrderDetails_Orders_OrderId",
				table: "OrderDetails");

			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Products_ProductId",
				table: "Orders");

			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Users_UserId",
				table: "Orders");

			migrationBuilder.DropIndex(
				name: "IX_Orders_ProductId",
				table: "Orders");

			migrationBuilder.DropIndex(
				name: "IX_Orders_UserId",
				table: "Orders");

			migrationBuilder.DropColumn(
				name: "DeliveredAt",
				table: "Orders");

			migrationBuilder.DropColumn(
				name: "ProductId",
				table: "Orders");

			migrationBuilder.RenameColumn(
				name: "TotalSum",
				table: "Orders",
				newName: "Price");

			migrationBuilder.RenameColumn(
				name: "OrderId",
				table: "OrderDetails",
				newName: "ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_OrderDetails_OrderId",
				table: "OrderDetails",
				newName: "IX_OrderDetails_ProductId");

			migrationBuilder.AddColumn<string>(
				name: "Description",
				table: "Orders",
				type: "text",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "ImagePath",
				table: "Orders",
				type: "text",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "Name",
				table: "Orders",
				type: "text",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<DateTime>(
				name: "CreatedAt",
				table: "OrderDetails",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<string>(
				name: "Description",
				table: "OrderDetails",
				type: "text",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<DateTime>(
				name: "EndDate",
				table: "OrderDetails",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<double>(
				name: "Price",
				table: "OrderDetails",
				type: "double precision",
				nullable: false,
				defaultValue: 0.0);

			migrationBuilder.AddColumn<DateTime>(
				name: "StartDate",
				table: "OrderDetails",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<DateTime>(
				name: "UpdatedAt",
				table: "OrderDetails",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.UpdateData(
				table: "Administators",
				keyColumn: "Id",
				keyValue: 1L,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2023, 2, 7, 9, 28, 25, 338, DateTimeKind.Utc).AddTicks(8524), new DateTime(2023, 2, 7, 9, 28, 25, 338, DateTimeKind.Utc).AddTicks(8526) });

			migrationBuilder.AddForeignKey(
				name: "FK_OrderDetails_Products_ProductId",
				table: "OrderDetails",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_OrderDetails_Products_ProductId",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "Description",
				table: "Orders");

			migrationBuilder.DropColumn(
				name: "ImagePath",
				table: "Orders");

			migrationBuilder.DropColumn(
				name: "Name",
				table: "Orders");

			migrationBuilder.DropColumn(
				name: "CreatedAt",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "Description",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "EndDate",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "Price",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "StartDate",
				table: "OrderDetails");

			migrationBuilder.DropColumn(
				name: "UpdatedAt",
				table: "OrderDetails");

			migrationBuilder.RenameColumn(
				name: "Price",
				table: "Orders",
				newName: "TotalSum");

			migrationBuilder.RenameColumn(
				name: "ProductId",
				table: "OrderDetails",
				newName: "OrderId");

			migrationBuilder.RenameIndex(
				name: "IX_OrderDetails_ProductId",
				table: "OrderDetails",
				newName: "IX_OrderDetails_OrderId");

			migrationBuilder.AddColumn<DateTime>(
				name: "DeliveredAt",
				table: "Orders",
				type: "timestamp with time zone",
				nullable: true);

			migrationBuilder.AddColumn<long>(
				name: "ProductId",
				table: "Orders",
				type: "bigint",
				nullable: false,
				defaultValue: 0L);

			migrationBuilder.UpdateData(
				table: "Administators",
				keyColumn: "Id",
				keyValue: 1L,
				columns: new[] { "CreatedAt", "UpdatedAt" },
				values: new object[] { new DateTime(2023, 2, 7, 4, 25, 10, 6, DateTimeKind.Utc).AddTicks(217), new DateTime(2023, 2, 7, 4, 25, 10, 6, DateTimeKind.Utc).AddTicks(221) });

			migrationBuilder.CreateIndex(
				name: "IX_Orders_ProductId",
				table: "Orders",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_Orders_UserId",
				table: "Orders",
				column: "UserId");

			migrationBuilder.AddForeignKey(
				name: "FK_OrderDetails_Orders_OrderId",
				table: "OrderDetails",
				column: "OrderId",
				principalTable: "Orders",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Products_ProductId",
				table: "Orders",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Users_UserId",
				table: "Orders",
				column: "UserId",
				principalTable: "Users",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
