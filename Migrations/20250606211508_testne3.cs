using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allSkillBack.Migrations
{
    /// <inheritdoc />
    public partial class testne3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "PcBudget");

            migrationBuilder.DropColumn(
                name: "Social",
                table: "PcBudget");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PcBudget",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Social",
                table: "PcBudget",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
