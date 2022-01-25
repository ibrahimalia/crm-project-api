using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class DealWithCreatedANDUpdatedBY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_MobRequests_MOB_SERVICE_MobServiceServicesId",
            //    table: "MobRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_PRJAddressType_AddressTypeId",
                table: "PRJContacts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PRJContacts_PRJJobPosition_JobPositionId",
            //    table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_CreatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_UpdatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropIndex(
                name: "IX_PRJContacts_AddressTypeId",
                table: "PRJContacts");

            //migrationBuilder.DropIndex(
            //    name: "IX_PRJContacts_JobPositionId",
            //    table: "PRJContacts");

            //migrationBuilder.DropIndex(
            //    name: "IX_MobRequests_MobServiceServicesId",
            //    table: "MobRequests");

            //migrationBuilder.DropColumn(
            //    name: "MobServiceServicesId",
            //    table: "MobRequests");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTaskStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTaskStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTaskHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTaskHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTaskFollower",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJTAG",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJTAG",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProjectCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProjectCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualEndDate",
                table: "PRJProject",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJJobPosition",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJJobPosition",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJInvolvementLevel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJInvolvementLevel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PRJJobPositionId",
                table: "PRJContacts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJAttachements",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJAttachements",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJAddressType",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJAddressType",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskStatus_CreatedBy",
                table: "PRJTaskStatus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskStatus_UpdatedBy",
                table: "PRJTaskStatus",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskHistory_CreatedBy",
                table: "PRJTaskHistory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskHistory_UpdatedBy",
                table: "PRJTaskHistory",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskFollower_CreatedBy",
                table: "PRJTaskFollower",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskFollower_UpdatedBy",
                table: "PRJTaskFollower",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTask_CreatedBy",
                table: "PRJTask",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTask_UpdatedBy",
                table: "PRJTask",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTAG_CreatedBy",
                table: "PRJTAG",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTAG_UpdatedBy",
                table: "PRJTAG",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectStatus_CreatedBy",
                table: "PRJProjectStatus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectStatus_UpdatedBy",
                table: "PRJProjectStatus",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectRole_CreatedBy",
                table: "PRJProjectRole",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectRole_UpdatedBy",
                table: "PRJProjectRole",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectHistory_CreatedBy",
                table: "PRJProjectHistory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectHistory_UpdatedBy",
                table: "PRJProjectHistory",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectFollowers_CreatedBy",
                table: "PRJProjectFollowers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectFollowers_UpdatedBy",
                table: "PRJProjectFollowers",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectCategory_CreatedBy",
                table: "PRJProjectCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectCategory_UpdatedBy",
                table: "PRJProjectCategory",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProject_CreatedBy",
                table: "PRJProject",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProject_UpdatedBy",
                table: "PRJProject",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJJobPosition_CreatedBy",
                table: "PRJJobPosition",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJJobPosition_UpdatedBy",
                table: "PRJJobPosition",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJContacts_CreatedBy",
                table: "PRJContacts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJContacts_PRJJobPositionId",
                table: "PRJContacts",
                column: "PRJJobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJContacts_UpdatedBy",
                table: "PRJContacts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJAttachements_CreatedBy",
                table: "PRJAttachements",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJAttachements_UpdatedBy",
                table: "PRJAttachements",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJAddressType_CreatedBy",
                table: "PRJAddressType",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJAddressType_UpdatedBy",
                table: "PRJAddressType",
                column: "UpdatedBy");

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
                name: "FK_PRJContacts_Accounts_UpdatedBy",
                table: "PRJContacts",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_PRJJobPosition_PRJJobPositionId",
                table: "PRJContacts",
                column: "PRJJobPositionId",
                principalTable: "PRJJobPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_PRJContacts_Accounts_UpdatedBy",
                table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_PRJJobPosition_PRJJobPositionId",
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

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskStatus_CreatedBy",
                table: "PRJTaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskStatus_UpdatedBy",
                table: "PRJTaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskHistory_CreatedBy",
                table: "PRJTaskHistory");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskHistory_UpdatedBy",
                table: "PRJTaskHistory");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskFollower_CreatedBy",
                table: "PRJTaskFollower");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskFollower_UpdatedBy",
                table: "PRJTaskFollower");

            migrationBuilder.DropIndex(
                name: "IX_PRJTask_CreatedBy",
                table: "PRJTask");

            migrationBuilder.DropIndex(
                name: "IX_PRJTask_UpdatedBy",
                table: "PRJTask");

            migrationBuilder.DropIndex(
                name: "IX_PRJTAG_CreatedBy",
                table: "PRJTAG");

            migrationBuilder.DropIndex(
                name: "IX_PRJTAG_UpdatedBy",
                table: "PRJTAG");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectStatus_CreatedBy",
                table: "PRJProjectStatus");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectStatus_UpdatedBy",
                table: "PRJProjectStatus");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectRole_CreatedBy",
                table: "PRJProjectRole");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectRole_UpdatedBy",
                table: "PRJProjectRole");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectHistory_CreatedBy",
                table: "PRJProjectHistory");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectHistory_UpdatedBy",
                table: "PRJProjectHistory");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectFollowers_CreatedBy",
                table: "PRJProjectFollowers");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectFollowers_UpdatedBy",
                table: "PRJProjectFollowers");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectCategory_CreatedBy",
                table: "PRJProjectCategory");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectCategory_UpdatedBy",
                table: "PRJProjectCategory");

            migrationBuilder.DropIndex(
                name: "IX_PRJProject_CreatedBy",
                table: "PRJProject");

            migrationBuilder.DropIndex(
                name: "IX_PRJProject_UpdatedBy",
                table: "PRJProject");

            migrationBuilder.DropIndex(
                name: "IX_PRJJobPosition_CreatedBy",
                table: "PRJJobPosition");

            migrationBuilder.DropIndex(
                name: "IX_PRJJobPosition_UpdatedBy",
                table: "PRJJobPosition");

            migrationBuilder.DropIndex(
                name: "IX_PRJContacts_CreatedBy",
                table: "PRJContacts");

            migrationBuilder.DropIndex(
                name: "IX_PRJContacts_PRJJobPositionId",
                table: "PRJContacts");

            migrationBuilder.DropIndex(
                name: "IX_PRJContacts_UpdatedBy",
                table: "PRJContacts");

            migrationBuilder.DropIndex(
                name: "IX_PRJAttachements_CreatedBy",
                table: "PRJAttachements");

            migrationBuilder.DropIndex(
                name: "IX_PRJAttachements_UpdatedBy",
                table: "PRJAttachements");

            migrationBuilder.DropIndex(
                name: "IX_PRJAddressType_CreatedBy",
                table: "PRJAddressType");

            migrationBuilder.DropIndex(
                name: "IX_PRJAddressType_UpdatedBy",
                table: "PRJAddressType");

            migrationBuilder.DropColumn(
                name: "ActualEndDate",
                table: "PRJProject");

            migrationBuilder.DropColumn(
                name: "PRJJobPositionId",
                table: "PRJContacts");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTaskStatus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTaskStatus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTaskHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTaskHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTaskFollower",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTaskFollower",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTask",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTask",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJTAG",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJTAG",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectStatus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectStatus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectRole",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectRole",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectFollowers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectFollowers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProjectCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProjectCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJProject",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJProject",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJJobPosition",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJJobPosition",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJInvolvementLevel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJInvolvementLevel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJAttachements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJAttachements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJAddressType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJAddressType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MobServiceServicesId",
                table: "MobRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRJContacts_AddressTypeId",
                table: "PRJContacts",
                column: "AddressTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PRJContacts_JobPositionId",
            //    table: "PRJContacts",
            //    column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_MobRequests_MobServiceServicesId",
                table: "MobRequests",
                column: "MobServiceServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_MobServiceServicesId",
                table: "MobRequests",
                column: "MobServiceServicesId",
                principalTable: "MOB_SERVICE",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_PRJAddressType_AddressTypeId",
                table: "PRJContacts",
                column: "AddressTypeId",
                principalTable: "PRJAddressType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_PRJJobPosition_JobPositionId",
                table: "PRJContacts",
                column: "JobPositionId",
                principalTable: "PRJJobPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_CreatedBy",
                table: "PRJInvolvementLevel",
                column: "CreatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_UpdatedBy",
                table: "PRJInvolvementLevel",
                column: "UpdatedBy",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
