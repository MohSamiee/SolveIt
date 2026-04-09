using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveIt.DataLayer.Migrations
{
	/// <inheritdoc />
	public partial class _mig_Add_States_Table : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "AvatarAddress",
				schema: "auth",
				table: "Users",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.CreateTable(
				name: "States",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					ParentId = table.Column<long>(type: "bigint", nullable: true),
					Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CreatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
					LastModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
					IsActive = table.Column<bool>(type: "bit", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_States", x => x.Id);
					table.ForeignKey(
						name: "FK_States_States_ParentId",
						column: x => x.ParentId,
						principalTable: "States",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_States_ParentId",
				table: "States",
				column: "ParentId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "States");

			migrationBuilder.AlterColumn<string>(
				name: "AvatarAddress",
				schema: "auth",
				table: "Users",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");
		}
	}
}
