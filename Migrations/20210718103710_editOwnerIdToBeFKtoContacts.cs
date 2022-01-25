using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class editOwnerIdToBeFKtoContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTaskFollower_OwnerId",
                table: "PRJTask");

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJContacts_OwnerId",
                table: "PRJTask",
                column: "OwnerId",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJContacts_OwnerId",
                table: "PRJTask");

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTaskFollower_OwnerId",
                table: "PRJTask",
                column: "OwnerId",
                principalTable: "PRJTaskFollower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
