using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{

    public partial class FixProjectManagementModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_PRJContacts_PRJContactsId",
                table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJProject_PRJProjectId",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJContacts_ContactsId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJInvolvementLevel_ProjectLevelId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_PRJProjectFollowers_ProjectFollowerId",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTask_PRJTaskId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJContacts_ContactsId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJInvolvementLevel_TaskLevelId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJProject_ProjectId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJTask_PRJTaskId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_PRJTask_PRJTaskId",
                table: "PRJTaskHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_PRJTaskFollower_PRJTaskFollowerId",
                table: "PRJTaskHistory");

            //migrationBuilder.DropColumn(
            //    name: "TaskFollowerId",
            //    table: "PRJTaskHistory");

            //migrationBuilder.DropColumn(
            //    name: "TaskId",
            //    table: "PRJTaskHistory");

            //migrationBuilder.DropColumn(
            //    name: "ContactId",
            //    table: "PRJTaskFollower");

            //migrationBuilder.DropColumn(
            //    name: "InvolvementLevelId",
            //    table: "PRJTaskFollower");

            //migrationBuilder.DropColumn(
            //    name: "TaskId",
            //    table: "PRJTaskFollower");

            //migrationBuilder.DropColumn(
            //    name: "ParentTaskId",
            //    table: "PRJTask");

            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "PRJProjectHistory");

            //migrationBuilder.DropColumn(
            //    name: "ContactId",
            //    table: "PRJProjectFollowers");

            //migrationBuilder.DropColumn(
            //    name: "InvolvementLevelId",
            //    table: "PRJProjectFollowers");

            //migrationBuilder.DropColumn(
            //    name: "ParentProjectId",
            //    table: "PRJProject");

            //migrationBuilder.DropColumn(
            //    name: "ParentContactId",
            //    table: "PRJContacts");

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskId",
                table: "PRJTaskHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskFollowerId",
                table: "PRJTaskHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "ProjectId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContactsId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskId",
                table: "PRJTask",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectRoleId",
                table: "PRJTask",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskStatusId",
                table: "PRJTask",
                type: "int",
                nullable: true);

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
                name: "ContactsId",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRJProjectId",
                table: "PRJProject",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRJContactsId",
                table: "PRJContacts",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PRJTaskFollower_ProjectRoleId",
            //    table: "PRJTaskFollower",
            //    column: "ProjectRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTask_ProjectRoleId",
                table: "PRJTask",
                column: "ProjectRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTask_TaskStatusId",
                table: "PRJTask",
                column: "TaskStatusId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PRJProjectFollowers_ProjectRoleId",
            //    table: "PRJProjectFollowers",
            //    column: "ProjectRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_PRJContacts_PRJContactsId",
                table: "PRJContacts",
                column: "PRJContactsId",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJProject_PRJProjectId",
                table: "PRJProject",
                column: "PRJProjectId",
                principalTable: "PRJProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJContacts_ContactsId",
                table: "PRJProjectFollowers",
                column: "ContactsId",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJInvolvementLevel_ProjectLevelId",
                table: "PRJProjectFollowers",
                column: "ProjectLevelId",
                principalTable: "PRJInvolvementLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PRJProjectFollowers_PRJProjectRole_ProjectRoleId",
            //    table: "PRJProjectFollowers",
            //    column: "ProjectRoleId",
            //    principalTable: "PRJProjectRole",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJTask_PRJTaskId",
                table: "PRJTask",
                column: "PRJTaskId",
                principalTable: "PRJTask",
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
                name: "FK_PRJTaskFollower_PRJContacts_ContactsId",
                table: "PRJTaskFollower",
                column: "ContactsId",
                principalTable: "PRJContacts",
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
                name: "FK_PRJTaskFollower_PRJProject_ProjectId",
                table: "PRJTaskFollower",
                column: "ProjectId",
                principalTable: "PRJProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJProjectRole_ProjectRoleId",
                table: "PRJTaskFollower",
                column: "ProjectRoleId",
                principalTable: "PRJProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJTask_PRJTaskId",
                table: "PRJTaskFollower",
                column: "PRJTaskId",
                principalTable: "PRJTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_PRJTask_PRJTaskId",
                table: "PRJTaskHistory",
                column: "PRJTaskId",
                principalTable: "PRJTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_PRJTaskFollower_PRJTaskFollowerId",
                table: "PRJTaskHistory",
                column: "PRJTaskFollowerId",
                principalTable: "PRJTaskFollower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_PRJContacts_PRJContactsId",
                table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJProject_PRJProjectId",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJContacts_ContactsId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJInvolvementLevel_ProjectLevelId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJProjectRole_ProjectRoleId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_PRJProjectFollowers_ProjectFollowerId",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJProjectRole_ProjectRoleId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTask_PRJTaskId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJTaskStatus_TaskStatusId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJContacts_ContactsId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJInvolvementLevel_TaskLevelId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJProject_ProjectId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJProjectRole_ProjectRoleId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJTask_PRJTaskId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_PRJTask_PRJTaskId",
                table: "PRJTaskHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_PRJTaskFollower_PRJTaskFollowerId",
                table: "PRJTaskHistory");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskFollower_ProjectRoleId",
                table: "PRJTaskFollower");

            migrationBuilder.DropIndex(
                name: "IX_PRJTask_ProjectRoleId",
                table: "PRJTask");

            migrationBuilder.DropIndex(
                name: "IX_PRJTask_TaskStatusId",
                table: "PRJTask");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectFollowers_ProjectRoleId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropColumn(
                name: "ProjectRoleId",
                table: "PRJTask");

            migrationBuilder.DropColumn(
                name: "TaskStatusId",
                table: "PRJTask");

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskId",
                table: "PRJTaskHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskFollowerId",
                table: "PRJTaskHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TaskFollowerId",
                table: "PRJTaskHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "PRJTaskHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TaskLevelId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContactsId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvolvementLevelId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "PRJTaskFollower",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PRJTaskId",
                table: "PRJTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentTaskId",
                table: "PRJTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectFollowerId",
                table: "PRJProjectHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PRJProjectHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectLevelId",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContactsId",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvolvementLevelId",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PRJProjectId",
                table: "PRJProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentProjectId",
                table: "PRJProject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PRJContactsId",
                table: "PRJContacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentContactId",
                table: "PRJContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_PRJContacts_PRJContactsId",
                table: "PRJContacts",
                column: "PRJContactsId",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJProject_PRJProjectId",
                table: "PRJProject",
                column: "PRJProjectId",
                principalTable: "PRJProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJContacts_ContactsId",
                table: "PRJProjectFollowers",
                column: "ContactsId",
                principalTable: "PRJContacts",
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
                name: "FK_PRJTask_PRJTask_PRJTaskId",
                table: "PRJTask",
                column: "PRJTaskId",
                principalTable: "PRJTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJContacts_ContactsId",
                table: "PRJTaskFollower",
                column: "ContactsId",
                principalTable: "PRJContacts",
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
                name: "FK_PRJTaskFollower_PRJProject_ProjectId",
                table: "PRJTaskFollower",
                column: "ProjectId",
                principalTable: "PRJProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJTask_PRJTaskId",
                table: "PRJTaskFollower",
                column: "PRJTaskId",
                principalTable: "PRJTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_PRJTask_PRJTaskId",
                table: "PRJTaskHistory",
                column: "PRJTaskId",
                principalTable: "PRJTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_PRJTaskFollower_PRJTaskFollowerId",
                table: "PRJTaskHistory",
                column: "PRJTaskFollowerId",
                principalTable: "PRJTaskFollower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
