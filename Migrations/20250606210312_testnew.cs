using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allSkillBack.Migrations
{
    /// <inheritdoc />
    public partial class testnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PCs_PCId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PCId",
                table: "Tickets");

            migrationBuilder.AddColumn<Guid>(
                name: "PcBudgetId",
                table: "Tickets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WhoClaimedId",
                table: "Tickets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PcBudget",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Budget = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Social = table.Column<string>(type: "text", nullable: false),
                    SpecialRequest = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcBudget", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PcBudgetId",
                table: "Tickets",
                column: "PcBudgetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PCId",
                table: "Tickets",
                column: "PCId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PCs_PCId",
                table: "Tickets",
                column: "PCId",
                principalTable: "PCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PcBudget_PcBudgetId",
                table: "Tickets",
                column: "PcBudgetId",
                principalTable: "PcBudget",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PCs_PCId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PcBudget_PcBudgetId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "PcBudget");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PcBudgetId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PCId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PcBudgetId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "WhoClaimedId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PCId",
                table: "Tickets",
                column: "PCId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PCs_PCId",
                table: "Tickets",
                column: "PCId",
                principalTable: "PCs",
                principalColumn: "Id");
        }
    }
}
