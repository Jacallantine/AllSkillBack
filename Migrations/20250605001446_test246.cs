using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allSkillBack.Migrations
{
    /// <inheritdoc />
    public partial class test246 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PcOpti",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "PcOpti",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Internet",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Internet",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PcOpti");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PcOpti");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Internet");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Internet");
        }
    }
}
