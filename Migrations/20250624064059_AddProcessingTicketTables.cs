using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeafoodApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProcessingTicketTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryHistories");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ProcessingTicketOutputDetails");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ProcessingTicketInputDetails");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProductionOrders_ProductionOrderId",
                table: "ProcessingTickets");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingTickets_ProductionOrderId",
                table: "ProcessingTickets");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ProcessingTicketOutputDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ProcessingTicketInputDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InventoryHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActionType = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LotCode = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductType = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryHistories", x => x.Id);
                });
        }
    }
}
