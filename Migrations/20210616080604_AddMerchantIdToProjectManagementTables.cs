using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddMerchantIdToProjectManagementTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJTaskStatus",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJTaskStatus",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJTaskHistory",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJTaskHistory",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJTaskFollower",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJTaskFollower",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJTask",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJTask",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJTAG",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJTAG",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJProjectStatus",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJProjectStatus",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJProjectRole",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJProjectRole",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJProjectHistory",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJProjectHistory",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJProjectFollowers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJProjectFollowers",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJProjectCategory",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJProjectCategory",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJProject",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJProject",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJJobPosition",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJJobPosition",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJInvolvementLevel",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJInvolvementLevel",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJContacts",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJContacts",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJAttachements",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJAttachements",
                type: "nvarchar(450)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MerchantId",
            //    table: "PRJAddressType",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobMerchantMerchantId",
                table: "PRJAddressType",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskStatus_MobMerchantMerchantId",
                table: "PRJTaskStatus",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskHistory_MobMerchantMerchantId",
                table: "PRJTaskHistory",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskFollower_MobMerchantMerchantId",
                table: "PRJTaskFollower",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTask_MobMerchantMerchantId",
                table: "PRJTask",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTAG_MobMerchantMerchantId",
                table: "PRJTAG",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectStatus_MobMerchantMerchantId",
                table: "PRJProjectStatus",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectRole_MobMerchantMerchantId",
                table: "PRJProjectRole",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectHistory_MobMerchantMerchantId",
                table: "PRJProjectHistory",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectFollowers_MobMerchantMerchantId",
                table: "PRJProjectFollowers",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectCategory_MobMerchantMerchantId",
                table: "PRJProjectCategory",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProject_MobMerchantMerchantId",
                table: "PRJProject",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJJobPosition_MobMerchantMerchantId",
                table: "PRJJobPosition",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJInvolvementLevel_MobMerchantMerchantId",
                table: "PRJInvolvementLevel",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJContacts_MobMerchantMerchantId",
                table: "PRJContacts",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJAttachements_MobMerchantMerchantId",
                table: "PRJAttachements",
                column: "MobMerchantMerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJAddressType_MobMerchantMerchantId",
                table: "PRJAddressType",
                column: "MobMerchantMerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAddressType_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJAddressType",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJAttachements_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJAttachements",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJContacts",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJInvolvementLevel_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJInvolvementLevel",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJJobPosition_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJJobPosition",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProject",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectCategory_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectCategory",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectFollowers",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectHistory_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectHistory",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectRole_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectRole",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectStatus_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectStatus",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTAG_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTAG",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTask_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTask",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskFollower_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTaskFollower",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskHistory_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTaskHistory",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTaskStatus_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTaskStatus",
                column: "MobMerchantMerchantId",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJAddressType_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJAddressType");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJAttachements_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJAttachements");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJJobPosition_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJJobPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectCategory_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectHistory_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectRole_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectStatus_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJProjectStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTAG_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTAG");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTask_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTask");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskFollower_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTaskFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskHistory_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTaskHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJTaskStatus_MOB_MERCHANT_MobMerchantMerchantId",
                table: "PRJTaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskStatus_MobMerchantMerchantId",
                table: "PRJTaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskHistory_MobMerchantMerchantId",
                table: "PRJTaskHistory");

            migrationBuilder.DropIndex(
                name: "IX_PRJTaskFollower_MobMerchantMerchantId",
                table: "PRJTaskFollower");

            migrationBuilder.DropIndex(
                name: "IX_PRJTask_MobMerchantMerchantId",
                table: "PRJTask");

            migrationBuilder.DropIndex(
                name: "IX_PRJTAG_MobMerchantMerchantId",
                table: "PRJTAG");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectStatus_MobMerchantMerchantId",
                table: "PRJProjectStatus");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectRole_MobMerchantMerchantId",
                table: "PRJProjectRole");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectHistory_MobMerchantMerchantId",
                table: "PRJProjectHistory");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectFollowers_MobMerchantMerchantId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectCategory_MobMerchantMerchantId",
                table: "PRJProjectCategory");

            migrationBuilder.DropIndex(
                name: "IX_PRJProject_MobMerchantMerchantId",
                table: "PRJProject");

            migrationBuilder.DropIndex(
                name: "IX_PRJJobPosition_MobMerchantMerchantId",
                table: "PRJJobPosition");

            migrationBuilder.DropIndex(
                name: "IX_PRJInvolvementLevel_MobMerchantMerchantId",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropIndex(
                name: "IX_PRJContacts_MobMerchantMerchantId",
                table: "PRJContacts");

            migrationBuilder.DropIndex(
                name: "IX_PRJAttachements_MobMerchantMerchantId",
                table: "PRJAttachements");

            migrationBuilder.DropIndex(
                name: "IX_PRJAddressType_MobMerchantMerchantId",
                table: "PRJAddressType");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJTaskStatus");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJTaskStatus");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJTaskHistory");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJTaskHistory");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJTaskFollower");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJTaskFollower");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJTask");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJTask");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJTAG");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJTAG");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJProjectStatus");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJProjectStatus");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJProjectRole");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJProjectRole");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJProjectHistory");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJProjectHistory");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJProjectFollowers");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJProjectCategory");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJProjectCategory");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJProject");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJProject");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJJobPosition");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJJobPosition");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJContacts");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJContacts");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJAttachements");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJAttachements");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PRJAddressType");

            migrationBuilder.DropColumn(
                name: "MobMerchantMerchantId",
                table: "PRJAddressType");
        }
    }
}
