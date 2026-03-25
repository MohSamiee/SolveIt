using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveIt.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class _mig_Update_UserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                schema: "auth",
                table: "Users",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                schema: "auth",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GetNewLetter",
                schema: "auth",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                schema: "auth",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Company",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GetNewLetter",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                schema: "auth",
                table: "Users");
        }
    }
}
