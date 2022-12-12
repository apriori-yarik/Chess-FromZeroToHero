using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessFromZeroToHero.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedForeignKeyConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_BlackUserId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_WhiteUserId",
                table: "Game");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_BlackUserId",
                table: "Game",
                column: "BlackUserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_WhiteUserId",
                table: "Game",
                column: "WhiteUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_BlackUserId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_WhiteUserId",
                table: "Game");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_BlackUserId",
                table: "Game",
                column: "BlackUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_WhiteUserId",
                table: "Game",
                column: "WhiteUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
