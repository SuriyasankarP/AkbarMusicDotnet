using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class ForiegnKeyRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayList_User_UserId",
                table: "PlayList");

            migrationBuilder.DropIndex(
                name: "IX_PlayList_UserId",
                table: "PlayList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PlayList_UserId",
                table: "PlayList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayList_User_UserId",
                table: "PlayList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
