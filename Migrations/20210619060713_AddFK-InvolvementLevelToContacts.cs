using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddFKInvolvementLevelToContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_Accounts_AccountsId",
                table: "MobRequests");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_MobRequests_MOB_SERVICE_ServicesId",
            //    table: "MobRequests");

            //migrationBuilder.RenameColumn(
            //    name: "ServicesId",
            //    table: "MobRequests",
            //    newName: "MobServiceServicesId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_MobRequests_ServicesId",
            //    table: "MobRequests",
            //    newName: "IX_MobRequests_MobServiceServicesId");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "PRJInvolvementLevel",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PRJInvolvementLevel",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountsId",
                table: "MobRequests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_PRJInvolvementLevel_CreatedBy",
                table: "PRJInvolvementLevel",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRJInvolvementLevel_UpdatedBy",
                table: "PRJInvolvementLevel",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_Accounts_AccountsId",
                table: "MobRequests",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MobRequests_MOB_SERVICE_MobServiceServicesId",
            //    table: "MobRequests",
            //    column: "MobServiceServicesId",
            //    principalTable: "MOB_SERVICE",
            //    principalColumn: "ServicesId",
            //    onDelete: ReferentialAction.Restrict);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_Accounts_AccountsId",
                table: "MobRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_MobServiceServicesId",
                table: "MobRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_CreatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJInvolvementLevel_PRJContacts_UpdatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropIndex(
                name: "IX_PRJInvolvementLevel_CreatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.DropIndex(
                name: "IX_PRJInvolvementLevel_UpdatedBy",
                table: "PRJInvolvementLevel");

            migrationBuilder.RenameColumn(
                name: "MobServiceServicesId",
                table: "MobRequests",
                newName: "ServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_MobRequests_MobServiceServicesId",
                table: "MobRequests",
                newName: "IX_MobRequests_ServicesId");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJInvolvementLevel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PRJInvolvementLevel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "AccountsId",
                table: "MobRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_Accounts_AccountsId",
                table: "MobRequests",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_ServicesId",
                table: "MobRequests",
                column: "ServicesId",
                principalTable: "MOB_SERVICE",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
