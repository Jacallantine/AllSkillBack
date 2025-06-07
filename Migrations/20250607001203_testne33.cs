using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allSkillBack.Migrations
{
    /// <inheritdoc />
    public partial class testne33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Social",
                table: "PcBudget",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Social",
                table: "PcBudget");
        }
    }
}
