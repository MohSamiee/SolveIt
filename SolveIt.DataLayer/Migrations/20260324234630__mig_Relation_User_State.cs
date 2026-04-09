using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveIt.DataLayer.Migrations
{
	/// <inheritdoc />
	public partial class _mig_Relation_User_State : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "BirthDate",
				schema: "auth",
				table: "Users",
				type: "datetime2",
				nullable: true);

			migrationBuilder.AddColumn<long>(
				name: "CityId",
				schema: "auth",
				table: "Users",
				type: "bigint",
				nullable: true);

			migrationBuilder.AddColumn<long>(
				name: "CountryId",
				schema: "auth",
				table: "Users",
				type: "bigint",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Users_CityId",
				schema: "auth",
				table: "Users",
				column: "CityId");

			migrationBuilder.CreateIndex(
				name: "IX_Users_CountryId",
				schema: "auth",
				table: "Users",
				column: "CountryId");

			migrationBuilder.AddForeignKey(
				name: "FK_Users_States_CityId",
				schema: "auth",
				table: "Users",
				column: "CityId",
				principalTable: "States",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Users_States_CountryId",
				schema: "auth",
				table: "Users",
				column: "CountryId",
				principalTable: "States",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Users_States_CityId",
				schema: "auth",
				table: "Users");

			migrationBuilder.DropForeignKey(
				name: "FK_Users_States_CountryId",
				schema: "auth",
				table: "Users");

			migrationBuilder.DropIndex(
				name: "IX_Users_CityId",
				schema: "auth",
				table: "Users");

			migrationBuilder.DropIndex(
				name: "IX_Users_CountryId",
				schema: "auth",
				table: "Users");

			migrationBuilder.DropColumn(
				name: "BirthDate",
				schema: "auth",
				table: "Users");

			migrationBuilder.DropColumn(
				name: "CityId",
				schema: "auth",
				table: "Users");

			migrationBuilder.DropColumn(
				name: "CountryId",
				schema: "auth",
				table: "Users");
		}
	}
}
