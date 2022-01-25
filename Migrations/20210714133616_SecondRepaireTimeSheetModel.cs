using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class SecondRepaireTimeSheetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "PRJTimeSheet");

            migrationBuilder.RenameColumn(
                name: "ToTime",
                table: "PRJTimeSheet",
                newName: "Day");

            migrationBuilder.AddColumn<int>(
                name: "FromHour",
                table: "PRJTimeSheet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromMinute",
                table: "PRJTimeSheet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToHour",
                table: "PRJTimeSheet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToMinute",
                table: "PRJTimeSheet",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromHour",
                table: "PRJTimeSheet");

            migrationBuilder.DropColumn(
                name: "FromMinute",
                table: "PRJTimeSheet");

            migrationBuilder.DropColumn(
                name: "ToHour",
                table: "PRJTimeSheet");

            migrationBuilder.DropColumn(
                name: "ToMinute",
                table: "PRJTimeSheet");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "PRJTimeSheet",
                newName: "ToTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromTime",
                table: "PRJTimeSheet",
                type: "datetime2",
                nullable: true);
        }
    }
}
