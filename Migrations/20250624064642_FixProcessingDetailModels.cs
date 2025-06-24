using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeafoodApp.Migrations
{
    /// <inheritdoc />
    public partial class FixProcessingDetailModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProductionOrders_ProductionOrderId",
                table: "ProcessingTickets");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingTickets_ProductionOrderId",
                table: "ProcessingTickets");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingTickets_ProductionOrderId",
                table: "ProcessingTickets",
                column: "ProductionOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingTickets_ProductionOrders_ProductionOrderId",
                table: "ProcessingTickets",
                column: "ProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
