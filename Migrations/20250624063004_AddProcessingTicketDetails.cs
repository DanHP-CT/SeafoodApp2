using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeafoodApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProcessingTicketDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProductionOrders_ProductionOrderId",
                table: "ProcessingTickets");

            migrationBuilder.DropTable(
                name: "ProcessingTicketDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingTickets_ProductionOrderId",
                table: "ProcessingTickets");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "ProcessingTicketInputDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessingTicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingTicketInputDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingTicketInputDetails_ProcessingTickets_ProcessingTicketId",
                        column: x => x.ProcessingTicketId,
                        principalTable: "ProcessingTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingTicketOutputDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessingTicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingTicketOutputDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingTicketOutputDetails_ProcessingTickets_ProcessingTicketId",
                        column: x => x.ProcessingTicketId,
                        principalTable: "ProcessingTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingTicketInputDetails_ProcessingTicketId",
                table: "ProcessingTicketInputDetails",
                column: "ProcessingTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingTicketOutputDetails_ProcessingTicketId",
                table: "ProcessingTicketOutputDetails",
                column: "ProcessingTicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessingTicketInputDetails");

            migrationBuilder.DropTable(
                name: "ProcessingTicketOutputDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProcessingTicketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessingTicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsInput = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingTicketDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingTicketDetails_ProcessingTickets_ProcessingTicketId",
                        column: x => x.ProcessingTicketId,
                        principalTable: "ProcessingTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingTickets_ProductionOrderId",
                table: "ProcessingTickets",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingTicketDetails_ProcessingTicketId",
                table: "ProcessingTicketDetails",
                column: "ProcessingTicketId");

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
