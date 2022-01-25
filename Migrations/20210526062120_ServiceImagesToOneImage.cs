using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class ServiceImagesToOneImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "MOB_SERVICE",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationCode",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationCode",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "MOB_SERVICE",
                newName: "Images");
        }
    }
}
