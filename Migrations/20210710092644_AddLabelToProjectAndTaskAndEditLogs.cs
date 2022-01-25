using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddLabelToProjectAndTaskAndEditLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Accounts_AccountsId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAttachements_PRJTask_TaskId",
                table: "PRJAttachements");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJProjectCategory_ProjectCategoryId",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJProjectStatus_ProjectStatusId",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJInvolvementLevel_ProjectLevelId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_PRJProjectFollowers_ProjectFollowerId",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTaskFollower_OwnerId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJInvolvementLevel_TaskLevelId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJProjectRole_ProjectRoleId",
                table: "PRJTaskFollower");

            //migrationBuilder.DropColumn(
            //    name: "JobPositionId",
            //    table: "PRJContacts");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "PRJTaskHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "PRJTaskHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaskLevelId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectRoleId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "PRJTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "PRJTask",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectFollowerId",
                table: "PRJProjectHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "PRJProjectHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "PRJProjectHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectLevelId",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectStatusId",
                table: "PRJProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCategoryId",
                table: "PRJProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "PRJProject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressTypeId",
                table: "PRJContacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "PRJAttachements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "AccountsId",
                table: "FeedBacks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Accounts_AccountsId",
                table: "FeedBacks",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAttachements_PRJTask_TaskId",
                table: "PRJAttachements",
                column: "TaskId",
                principalTable: "PRJTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJProjectCategory_ProjectCategoryId",
                table: "PRJProject",
                column: "ProjectCategoryId",
                principalTable: "PRJProjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJProjectStatus_ProjectStatusId",
                table: "PRJProject",
                column: "ProjectStatusId",
                principalTable: "PRJProjectStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJInvolvementLevel_ProjectLevelId",
                table: "PRJProjectFollowers",
                column: "ProjectLevelId",
                principalTable: "PRJInvolvementLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectHistory_PRJProjectFollowers_ProjectFollowerId",
                table: "PRJProjectHistory",
                column: "ProjectFollowerId",
                principalTable: "PRJProjectFollowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
                table: "PRJTask",
                column: "ProjectRoleId",
                principalTable: "PRJProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTaskFollower_OwnerId",
                table: "PRJTask",
                column: "OwnerId",
                principalTable: "PRJTaskFollower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
                table: "PRJTask",
                column: "TaskStatusId",
                principalTable: "PRJTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJInvolvementLevel_TaskLevelId",
                table: "PRJTaskFollower",
                column: "TaskLevelId",
                principalTable: "PRJInvolvementLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJProjectRole_ProjectRoleId",
                table: "PRJTaskFollower",
                column: "ProjectRoleId",
                principalTable: "PRJProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Accounts_AccountsId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAttachements_PRJTask_TaskId",
                table: "PRJAttachements");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJProjectCategory_ProjectCategoryId",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJProjectStatus_ProjectStatusId",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJInvolvementLevel_ProjectLevelId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_PRJProjectFollowers_ProjectFollowerId",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTaskFollower_OwnerId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJInvolvementLevel_TaskLevelId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJProjectRole_ProjectRoleId",
                table: "PRJTaskFollower");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "PRJTaskHistory");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "PRJTaskHistory");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "PRJTask");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "PRJProjectHistory");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "PRJProjectHistory");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "PRJProject");

            migrationBuilder.AlterColumn<int>(
                name: "TaskLevelId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectRoleId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "PRJTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectFollowerId",
                table: "PRJProjectHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectLevelId",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectStatusId",
                table: "PRJProject",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCategoryId",
                table: "PRJProject",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressTypeId",
                table: "PRJContacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "JobPositionId",
            //    table: "PRJContacts",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "PRJAttachements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountsId",
                table: "FeedBacks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Accounts_AccountsId",
                table: "FeedBacks",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAttachements_PRJTask_TaskId",
                table: "PRJAttachements",
                column: "TaskId",
                principalTable: "PRJTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJProjectCategory_ProjectCategoryId",
                table: "PRJProject",
                column: "ProjectCategoryId",
                principalTable: "PRJProjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJProjectStatus_ProjectStatusId",
                table: "PRJProject",
                column: "ProjectStatusId",
                principalTable: "PRJProjectStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJInvolvementLevel_ProjectLevelId",
                table: "PRJProjectFollowers",
                column: "ProjectLevelId",
                principalTable: "PRJInvolvementLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectHistory_PRJProjectFollowers_ProjectFollowerId",
                table: "PRJProjectHistory",
                column: "ProjectFollowerId",
                principalTable: "PRJProjectFollowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
                table: "PRJTask",
                column: "ProjectRoleId",
                principalTable: "PRJProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTaskFollower_OwnerId",
                table: "PRJTask",
                column: "OwnerId",
                principalTable: "PRJTaskFollower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
                table: "PRJTask",
                column: "TaskStatusId",
                principalTable: "PRJTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJInvolvementLevel_TaskLevelId",
                table: "PRJTaskFollower",
                column: "TaskLevelId",
                principalTable: "PRJInvolvementLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJProjectRole_ProjectRoleId",
                table: "PRJTaskFollower",
                column: "ProjectRoleId",
                principalTable: "PRJProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
