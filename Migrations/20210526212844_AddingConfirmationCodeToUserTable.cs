using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddingConfirmationCodeToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Accounts",
                newName: "LastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationCodeEndDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationCodeEndDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Accounts",
                newName: "Name");
        }
    }
}
