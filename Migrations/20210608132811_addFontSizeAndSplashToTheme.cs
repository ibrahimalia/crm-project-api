using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class addFontSizeAndSplashToTheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FontSize",
                table: "MOB_GLOBAL_THEME",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SplashScreenColor",
                table: "MOB_GLOBAL_THEME",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SplashScreenTitle",
                table: "MOB_GLOBAL_THEME",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FontSize",
                table: "MOB_GLOBAL_THEME");

            migrationBuilder.DropColumn(
                name: "SplashScreenColor",
                table: "MOB_GLOBAL_THEME");

            migrationBuilder.DropColumn(
                name: "SplashScreenTitle",
                table: "MOB_GLOBAL_THEME");
        }
    }
}
