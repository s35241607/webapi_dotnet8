using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi_dotnet8.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JoinedAt",
                table: "UserServers",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserServers",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserServers");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UserServers",
                newName: "JoinedAt");
        }
    }
}
