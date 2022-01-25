using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddRelationBetweenTaskOwnerAndTaskFollower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PRJTask_PRJTask_PRJTaskId",
            //    table: "PRJTask");

            //migrationBuilder.DropColumn(
            //    name: "ProjectRoleId",
            //    table: "PRJProjectFollowers");

            //migrationBuilder.AlterColumn<int>(
            //    name: "PRJTaskId",
            //    table: "PRJTask",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTask_OwnerId",
                table: "PRJTask",
                column: "OwnerId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PRJTask_PRJTask_PRJTaskId",
            //    table: "PRJTask",
            //    column: "PRJTaskId",
            //    principalTable: "PRJTask",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTaskFollower_OwnerId",
                table: "PRJTask",
                column: "OwnerId",
                principalTable: "PRJTaskFollower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTask_PRJTaskId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTaskFollower_OwnerId",
                table: "PRJTask");

            migrationBuilder.DropIndex(
                name: "IX_PRJTask_OwnerId",
                table: "PRJTask");

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskId",
                table: "PRJTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectRoleId",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTask_PRJTaskId",
                table: "PRJTask",
                column: "PRJTaskId",
                principalTable: "PRJTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
