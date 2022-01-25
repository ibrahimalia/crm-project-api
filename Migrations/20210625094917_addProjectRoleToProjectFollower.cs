using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class addProjectRoleToProjectFollower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PRJContacts_Accounts_UpdatedBy",
            //    table: "PRJContacts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PRJContacts_PRJContacts_PRJContactsId",
            //    table: "PRJContacts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PRJProjectFollowers_PRJProjectRole_ProjectRoleId",
            //    table: "PRJProjectFollowers");

            //migrationBuilder.DropIndex(
            //    name: "IX_PRJProjectFollowers_ProjectRoleId",
            //    table: "PRJProjectFollowers");

            migrationBuilder.AddColumn<int>(
                name: "PRJProjectRole",
                table: "PRJProjectFollowers",
                type: "int",
                nullable: true);

            //migrationBuilder.AlterColumn<long>(
            //    name: "UpdatedBy",
            //    table: "PRJContacts",
            //    type: "bigint",
            //    nullable: true,
            //    oldClrType: typeof(long),
            //    oldType: "bigint");

            //migrationBuilder.AlterColumn<int>(
            //    name: "PRJContactsId",
            //    table: "PRJContacts",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectFollowers_PRJProjectRole",
                table: "PRJProjectFollowers",
                column: "PRJProjectRole");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PRJContacts_Accounts_UpdatedBy",
            //    table: "PRJContacts",
            //    column: "UpdatedBy",
            //    principalTable: "Accounts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PRJContacts_PRJContacts_PRJContactsId",
            //    table: "PRJContacts",
            //    column: "PRJContactsId",
            //    principalTable: "PRJContacts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJProjectRole_PRJProjectRole",
                table: "PRJProjectFollowers",
                column: "PRJProjectRole",
                principalTable: "PRJProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_Accounts_UpdatedBy",
                table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJContacts_PRJContacts_PRJContactsId",
                table: "PRJContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProjectFollowers_PRJProjectRole_PRJProjectRole",
                table: "PRJProjectFollowers");

            migrationBuilder.DropIndex(
                name: "IX_PRJProjectFollowers_PRJProjectRole",
                table: "PRJProjectFollowers");

            migrationBuilder.DropColumn(
                name: "PRJProjectRole",
                table: "PRJProjectFollowers");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PRJContacts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRJContactsId",
                table: "PRJContacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectFollowers_ProjectRoleId",
                table: "PRJProjectFollowers",
                column: "ProjectRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_Accounts_UpdatedBy",
                table: "PRJContacts",
                column: "UpdatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJContacts_PRJContacts_PRJContactsId",
                table: "PRJContacts",
                column: "PRJContactsId",
                principalTable: "PRJContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProjectFollowers_PRJProjectRole_ProjectRoleId",
                table: "PRJProjectFollowers",
                column: "ProjectRoleId",
                principalTable: "PRJProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
