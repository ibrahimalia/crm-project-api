using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddingIsActiveAndUserTypeToAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "SERVICE_FK",
                table: "MOB_IMAGE");

            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MOB_IMAGE_MOB_SERVICE_ServiceId",
                table: "MOB_IMAGE",
                column: "ServiceId",
                principalTable: "MOB_SERVICE",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MOB_IMAGE_MOB_SERVICE_ServiceId",
                table: "MOB_IMAGE");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Accounts");

            migrationBuilder.AddForeignKey(
                name: "SERVICE_FK",
                table: "MOB_IMAGE",
                column: "ServiceId",
                principalTable: "MOB_SERVICE",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
