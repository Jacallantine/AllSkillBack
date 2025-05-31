using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allSkillBack.Migrations
{
    /// <inheritdoc />
    public partial class test243 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Storage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Ram",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Psu",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Mobo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Gpu",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Cpu",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Case",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Ram");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Psu");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Mobo");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Gpu");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cpu");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Case");
        }
    }
}
