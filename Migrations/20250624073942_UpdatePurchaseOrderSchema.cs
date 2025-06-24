using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeafoodApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePurchaseOrderSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "PurchaseOrders");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "PurchaseOrders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "PurchaseOrderDetails",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "PurchaseOrderDetails",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "PurchaseOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "PurchaseOrderDetails",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "PurchaseOrderDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "PurchaseOrderDetails");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "PurchaseOrders",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "PurchaseOrderDetails",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "PurchaseOrderDetails",
                newName: "Size");

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "PurchaseOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PurchaseOrderDetails",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
