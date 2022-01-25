using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddAccountIdToContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "PRJContacts",
                type: "bigint",
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PRJContacts_UserId",
                table: "PRJContacts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_Accounts_UserId",
                table: "PRJContacts",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_Accounts_UserId",
                table: "PRJContacts");

            migrationBuilder.DropIndex(
                name: "IX_PRJContacts_UserId",
                table: "PRJContacts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PRJContacts");
        }
    }
}
