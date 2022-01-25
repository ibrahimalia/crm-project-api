using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class EditCreatedAndUpdatedByToAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJAddressType_PRJContacts_CreatedBy",
                table: "PRJAddressType");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAddressType_PRJContacts_UpdatedBy",
                table: "PRJAddressType");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAttachements_PRJContacts_CreatedBy",
                table: "PRJAttachements");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAttachements_PRJContacts_UpdatedBy",
                table: "PRJAttachements");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_Accounts_CreatedBy",
                table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_CreatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_UpdatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJJobPosition_PRJContacts_CreatedBy",
                table: "PRJJobPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJJobPosition_PRJContacts_UpdatedBy",
                table: "PRJJobPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJContacts_CreatedBy",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJContacts_UpdatedBy",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectCategory_PRJContacts_CreatedBy",
                table: "PRJProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectCategory_PRJContacts_UpdatedBy",
                table: "PRJProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJContacts_CreatedBy",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJContacts_UpdatedBy",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_PRJContacts_CreatedBy",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_PRJContacts_UpdatedBy",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectRole_PRJContacts_CreatedBy",
                table: "PRJProjectRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectRole_PRJContacts_UpdatedBy",
                table: "PRJProjectRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectStatus_PRJContacts_CreatedBy",
                table: "PRJProjectStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectStatus_PRJContacts_UpdatedBy",
                table: "PRJProjectStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTAG_PRJContacts_CreatedBy",
                table: "PRJTAG");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTAG_PRJContacts_UpdatedBy",
                table: "PRJTAG");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJContacts_CreatedBy",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_PRJContacts_UpdatedBy",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJContacts_CreatedBy",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_PRJContacts_UpdatedBy",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_PRJContacts_CreatedBy",
                table: "PRJTaskHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_PRJContacts_UpdatedBy",
                table: "PRJTaskHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskStatus_PRJContacts_CreatedBy",
                table: "PRJTaskStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskStatus_PRJContacts_UpdatedBy",
                table: "PRJTaskStatus");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTaskStatus",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTaskStatus",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTaskHistory",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTaskHistory",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTaskFollower",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTaskFollower",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTask",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTask",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTAG",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTAG",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectStatus",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectStatus",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectRole",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectRole",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectHistory",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectHistory",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectFollowers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectFollowers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectCategory",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectCategory",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProject",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProject",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJJobPosition",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJJobPosition",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJInvolvementLevel",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJInvolvementLevel",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJContacts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJAttachements",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJAttachements",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJAddressType",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJAddressType",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAddressType_Accounts_CreatedBy",
                table: "PRJAddressType",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAddressType_Accounts_UpdatedBy",
                table: "PRJAddressType",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAttachements_Accounts_CreatedBy",
                table: "PRJAttachements",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAttachements_Accounts_UpdatedBy",
                table: "PRJAttachements",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_Accounts_CreatedBy",
                table: "PRJContacts",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJInvolvementLevel_Accounts_CreatedBy",
                table: "PRJInvolvementLevel",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJInvolvementLevel_Accounts_UpdatedBy",
                table: "PRJInvolvementLevel",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJJobPosition_Accounts_CreatedBy",
                table: "PRJJobPosition",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJJobPosition_Accounts_UpdatedBy",
                table: "PRJJobPosition",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_Accounts_CreatedBy",
                table: "PRJProject",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_Accounts_UpdatedBy",
                table: "PRJProject",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectCategory_Accounts_CreatedBy",
                table: "PRJProjectCategory",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectCategory_Accounts_UpdatedBy",
                table: "PRJProjectCategory",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_Accounts_CreatedBy",
                table: "PRJProjectFollowers",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_Accounts_UpdatedBy",
                table: "PRJProjectFollowers",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectHistory_Accounts_CreatedBy",
                table: "PRJProjectHistory",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectHistory_Accounts_UpdatedBy",
                table: "PRJProjectHistory",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectRole_Accounts_CreatedBy",
                table: "PRJProjectRole",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectRole_Accounts_UpdatedBy",
                table: "PRJProjectRole",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectStatus_Accounts_CreatedBy",
                table: "PRJProjectStatus",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectStatus_Accounts_UpdatedBy",
                table: "PRJProjectStatus",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTAG_Accounts_CreatedBy",
                table: "PRJTAG",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTAG_Accounts_UpdatedBy",
                table: "PRJTAG",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_Accounts_CreatedBy",
                table: "PRJTask",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_Accounts_UpdatedBy",
                table: "PRJTask",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_Accounts_CreatedBy",
                table: "PRJTaskFollower",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_Accounts_UpdatedBy",
                table: "PRJTaskFollower",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_Accounts_CreatedBy",
                table: "PRJTaskHistory",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_Accounts_UpdatedBy",
                table: "PRJTaskHistory",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskStatus_Accounts_CreatedBy",
                table: "PRJTaskStatus",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskStatus_Accounts_UpdatedBy",
                table: "PRJTaskStatus",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJAddressType_Accounts_CreatedBy",
                table: "PRJAddressType");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAddressType_Accounts_UpdatedBy",
                table: "PRJAddressType");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAttachements_Accounts_CreatedBy",
                table: "PRJAttachements");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAttachements_Accounts_UpdatedBy",
                table: "PRJAttachements");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_Accounts_CreatedBy",
                table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_Accounts_CreatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_Accounts_UpdatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJJobPosition_Accounts_CreatedBy",
                table: "PRJJobPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJJobPosition_Accounts_UpdatedBy",
                table: "PRJJobPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_Accounts_CreatedBy",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_Accounts_UpdatedBy",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectCategory_Accounts_CreatedBy",
                table: "PRJProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectCategory_Accounts_UpdatedBy",
                table: "PRJProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_Accounts_CreatedBy",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_Accounts_UpdatedBy",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_Accounts_CreatedBy",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_Accounts_UpdatedBy",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectRole_Accounts_CreatedBy",
                table: "PRJProjectRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectRole_Accounts_UpdatedBy",
                table: "PRJProjectRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectStatus_Accounts_CreatedBy",
                table: "PRJProjectStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectStatus_Accounts_UpdatedBy",
                table: "PRJProjectStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTAG_Accounts_CreatedBy",
                table: "PRJTAG");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTAG_Accounts_UpdatedBy",
                table: "PRJTAG");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_Accounts_CreatedBy",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_Accounts_UpdatedBy",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_Accounts_CreatedBy",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_Accounts_UpdatedBy",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_Accounts_CreatedBy",
                table: "PRJTaskHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_Accounts_UpdatedBy",
                table: "PRJTaskHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskStatus_Accounts_CreatedBy",
                table: "PRJTaskStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskStatus_Accounts_UpdatedBy",
                table: "PRJTaskStatus");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTaskStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTaskStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTaskHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTaskHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTAG",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTAG",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJJobPosition",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJJobPosition",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJInvolvementLevel",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJInvolvementLevel",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJContacts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJAttachements",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJAttachements",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJAddressType",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJAddressType",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAddressType_PRJContacts_CreatedBy",
                table: "PRJAddressType",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAddressType_PRJContacts_UpdatedBy",
                table: "PRJAddressType",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAttachements_PRJContacts_CreatedBy",
                table: "PRJAttachements",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAttachements_PRJContacts_UpdatedBy",
                table: "PRJAttachements",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_Accounts_CreatedBy",
                table: "PRJContacts",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_CreatedBy",
                table: "PRJInvolvementLevel",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_UpdatedBy",
                table: "PRJInvolvementLevel",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJJobPosition_PRJContacts_CreatedBy",
                table: "PRJJobPosition",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJJobPosition_PRJContacts_UpdatedBy",
                table: "PRJJobPosition",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJContacts_CreatedBy",
                table: "PRJProject",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJContacts_UpdatedBy",
                table: "PRJProject",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectCategory_PRJContacts_CreatedBy",
                table: "PRJProjectCategory",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectCategory_PRJContacts_UpdatedBy",
                table: "PRJProjectCategory",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJContacts_CreatedBy",
                table: "PRJProjectFollowers",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJContacts_UpdatedBy",
                table: "PRJProjectFollowers",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectHistory_PRJContacts_CreatedBy",
                table: "PRJProjectHistory",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectHistory_PRJContacts_UpdatedBy",
                table: "PRJProjectHistory",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectRole_PRJContacts_CreatedBy",
                table: "PRJProjectRole",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectRole_PRJContacts_UpdatedBy",
                table: "PRJProjectRole",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectStatus_PRJContacts_CreatedBy",
                table: "PRJProjectStatus",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectStatus_PRJContacts_UpdatedBy",
                table: "PRJProjectStatus",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTAG_PRJContacts_CreatedBy",
                table: "PRJTAG",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTAG_PRJContacts_UpdatedBy",
                table: "PRJTAG",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJContacts_CreatedBy",
                table: "PRJTask",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_PRJContacts_UpdatedBy",
                table: "PRJTask",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJContacts_CreatedBy",
                table: "PRJTaskFollower",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_PRJContacts_UpdatedBy",
                table: "PRJTaskFollower",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_PRJContacts_CreatedBy",
                table: "PRJTaskHistory",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_PRJContacts_UpdatedBy",
                table: "PRJTaskHistory",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskStatus_PRJContacts_CreatedBy",
                table: "PRJTaskStatus",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskStatus_PRJContacts_UpdatedBy",
                table: "PRJTaskStatus",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
