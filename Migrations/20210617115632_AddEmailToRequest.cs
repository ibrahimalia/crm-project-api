using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddEmailToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_ServiceId1",
                table: "MobRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJProject_PRJProjectId",
                table: "PRJProject");

            migrationBuilder.DropIndex(
                name: "IX_MobRequests_serviceId",
                table: "MobRequests");
         

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "MobRequests");

            migrationBuilder.AlterColumn<int>(
                name: "PRJProjectId",
                table: "PRJProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "MobRequests",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "ServicesId",
            //    table: "MobRequests",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_MobRequests_ServicesId",
            //    table: "MobRequests",
            //    column: "ServicesId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MobRequests_MOB_SERVICE_ServicesId",
            //    table: "MobRequests",
            //    column: "ServicesId",
            //    principalTable: "MOB_SERVICE",
            //    principalColumn: "ServicesId",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJProject_PRJProjectId",
                table: "PRJProject",
                column: "PRJProjectId",
                principalTable: "PRJProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_ServicesId",
                table: "MobRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PRJProject_PRJProject_PRJProjectId",
                table: "PRJProject");

            migrationBuilder.DropIndex(
                name: "IX_MobRequests_ServicesId",
                table: "MobRequests");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "MobRequests");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "MobRequests");

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJTaskStatus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJTaskHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJTaskFollower",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJTask",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJTAG",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJProjectStatus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJProjectRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJProjectHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJProjectFollowers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJProjectCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRJProjectId",
                table: "PRJProject",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJProject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJJobPosition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJInvolvementLevel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJAttachements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "PRJAddressType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "MobRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MobRequests_serviceId",
                table: "MobRequests",
                column: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_serviceId",
                table: "MobRequests",
                column: "serviceId",
                principalTable: "MOB_SERVICE",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRJProject_PRJProject_PRJProjectId",
                table: "PRJProject",
                column: "PRJProjectId",
                principalTable: "PRJProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
