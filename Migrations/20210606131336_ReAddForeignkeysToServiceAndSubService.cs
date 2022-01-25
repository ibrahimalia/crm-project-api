using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class ReAddForeignkeysToServiceAndSubService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "MobRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subServiceId",
                table: "MobRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MobRequests_serviceId",
                table: "MobRequests",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_MobRequests_subServiceId",
                table: "MobRequests",
                column: "subServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_ServiceId1",
                table: "MobRequests",
                column: "serviceId",
                principalTable: "MOB_SERVICE",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_MOB_SUB_SERVICE_subServiceId",
                table: "MobRequests",
                column: "subServiceId",
                principalTable: "MOB_SUB_SERVICE",
                principalColumn: "SubServicesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_ServiceId",
                table: "MobRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_MOB_SUB_SERVICE_SubServiceId",
                table: "MobRequests");

            migrationBuilder.DropIndex(
                name: "IX_MobRequests_ServiceId",
                table: "MobRequests");

            migrationBuilder.DropIndex(
                name: "IX_MobRequests_SubServiceId",
                table: "MobRequests");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "MobRequests");

            migrationBuilder.DropColumn(
                name: "SubServiceId",
                table: "MobRequests");

            migrationBuilder.RenameColumn(
                name: "SubServiceId",
                table: "MobRequests",
                newName: "SubServiceID");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "MobRequests",
                newName: "ServiceID");
        }
    }
}
