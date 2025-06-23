using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeafoodApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProductionOrderDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "PriceListNumber",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "PurchaseOrderDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "PurchaseOrderDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PriceListNumber",
                table: "PurchaseOrderDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "PurchaseOrderDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
