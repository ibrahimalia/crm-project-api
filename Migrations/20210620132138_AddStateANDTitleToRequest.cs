using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddStateANDTitleToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedAt",
                table: "MobRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MobRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MobRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedAt",
                table: "MobRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MobRequests");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MobRequests");
        }
    }
}
