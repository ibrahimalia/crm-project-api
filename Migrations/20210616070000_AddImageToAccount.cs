using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddImageToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
            //    table: "PRJTask");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
            //    table: "PRJTask");

            migrationBuilder.DropColumn(
                name: "AssignToProjectRoleId",
                table: "PRJTask");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PRJTask");

            migrationBuilder.AlterColumn<int>(
                name: "TaskStatusId",
                table: "PRJTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectRoleId",
                table: "PRJTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
            //    table: "PRJTask",
            //    column: "ProjectRoleId",
            //    principalTable: "PRJProjectRole",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
            //    table: "PRJTask",
            //    column: "TaskStatusId",
            //    principalTable: "PRJTaskStatus",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
                table: "PRJTask");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "TaskStatusId",
                table: "PRJTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectRoleId",
                table: "PRJTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AssignToProjectRoleId",
                table: "PRJTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PRJTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
                table: "PRJTask",
                column: "ProjectRoleId",
                principalTable: "PRJProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
                table: "PRJTask",
                column: "TaskStatusId",
                principalTable: "PRJTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
