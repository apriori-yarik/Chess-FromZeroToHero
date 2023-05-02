using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessFromZeroToHero.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
