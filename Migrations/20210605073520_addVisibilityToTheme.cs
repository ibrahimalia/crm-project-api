using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class addVisibilityToTheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MOB_GLOBAL_THEME");

            migrationBuilder.AddColumn<bool>(
                name: "GallerySlider",
                table: "MOB_GLOBAL_THEME",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "MainSlider",
                table: "MOB_GLOBAL_THEME",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "NewsSlider",
                table: "MOB_GLOBAL_THEME",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProjectSlider",
                table: "MOB_GLOBAL_THEME",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesSlider",
                table: "MOB_GLOBAL_THEME",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GallerySlider",
                table: "MOB_GLOBAL_THEME");

            migrationBuilder.DropColumn(
                name: "MainSlider",
                table: "MOB_GLOBAL_THEME");

            migrationBuilder.DropColumn(
                name: "NewsSlider",
                table: "MOB_GLOBAL_THEME");

            migrationBuilder.DropColumn(
                name: "ProjectSlider",
                table: "MOB_GLOBAL_THEME");

            migrationBuilder.DropColumn(
                name: "ServicesSlider",
                table: "MOB_GLOBAL_THEME");

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "MOB_GLOBAL_THEME",
                type: "int",
                nullable: true,
                defaultValueSql: "'1'");
        }
    }
}
