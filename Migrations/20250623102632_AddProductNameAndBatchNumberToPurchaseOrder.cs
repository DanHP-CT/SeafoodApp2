using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeafoodApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProductNameAndBatchNumberToPurchaseOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "PurchaseOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "PurchaseOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "PurchaseOrders");
        }
    }
}
