using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveIt.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class _mig_ReInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmailActivationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpireEmailActivationCode = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MobileActivationCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMobileConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExpireMobileActivationCode = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AvatarAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBan = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "auth");
        }
    }
}
