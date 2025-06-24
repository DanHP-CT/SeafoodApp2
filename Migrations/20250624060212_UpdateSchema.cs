using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeafoodApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "DurationHours",
                table: "ProcessingTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
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

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "ProcessingTicketDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "ProcessingTicketDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProcessSteps_ProcessStepId",
                table: "ProcessingTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingTickets_ProductionOrders_ProductionOrderId",
                table: "ProcessingTickets");

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
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "ProcessingTickets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "ProcessingTicketDetails",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "ProcessingTicketDetails",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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
    }
}
