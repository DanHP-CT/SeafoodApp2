using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeafoodApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbAfterRemoveProcessingItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProcessSteps_ProcessStepId",
                table: "ProcessingTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProductionOrders_ProductionOrderId",
                table: "ProcessingTickets");

            migrationBuilder.DropTable(
                name: "ProcessingItems");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerCount",
                table: "ProcessingTickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionOrderId",
                table: "ProcessingTickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessStepId",
                table: "ProcessingTickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "DurationHours",
                table: "ProcessingTickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "ProcessingTicketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessingTicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: true),
                    IsInput = table.Column<bool>(type: "INTEGER", nullable: false)
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
                name: "IX_ProcessingTicketDetails_ProcessingTicketId",
                table: "ProcessingTicketDetails",
                column: "ProcessingTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingTickets_ProcessSteps_ProcessStepId",
                table: "ProcessingTickets",
                column: "ProcessStepId",
                principalTable: "ProcessSteps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingTickets_ProductionOrders_ProductionOrderId",
                table: "ProcessingTickets",
                column: "ProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProcessSteps_ProcessStepId",
                table: "ProcessingTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProductionOrders_ProductionOrderId",
                table: "ProcessingTickets");

            migrationBuilder.DropTable(
                name: "ProcessingTicketDetails");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerCount",
                table: "ProcessingTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductionOrderId",
                table: "ProcessingTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessStepId",
                table: "ProcessingTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DurationHours",
                table: "ProcessingTickets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProcessingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessingTicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    QuantityIn = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityOut = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingItems_ProcessingTickets_ProcessingTicketId",
                        column: x => x.ProcessingTicketId,
                        principalTable: "ProcessingTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingItems_ProcessingTicketId",
                table: "ProcessingItems",
                column: "ProcessingTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingTickets_ProcessSteps_ProcessStepId",
                table: "ProcessingTickets",
                column: "ProcessStepId",
                principalTable: "ProcessSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
