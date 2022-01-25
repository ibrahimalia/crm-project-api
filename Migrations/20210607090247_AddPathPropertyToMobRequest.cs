using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddPathPropertyToMobRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_MobRequests_MOB_SERVICE_ServicesId",
            //    table: "MobRequests");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_MobRequests_MOB_SUB_SERVICE_SubServicesId",
            //    table: "MobRequests");

            //migrationBuilder.DropIndex(
            //    name: "IX_MobRequests_ServicesId",
            //    table: "MobRequests");

            //migrationBuilder.DropIndex(
            //    name: "IX_MobRequests_SubServicesId",
            //    table: "MobRequests");

            //migrationBuilder.DropColumn(
            //    name: "ServicesId",
            //    table: "MobRequests");

            //migrationBuilder.DropColumn(
            //    name: "SubServicesId",
            //    table: "MobRequests");

            //migrationBuilder.RenameColumn(
            //    name: "SubServicesId1",
            //    table: "MobRequests",
            //    newName: "subServiceId");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "MobRequests",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_MobRequests_serviceId",
            //    table: "MobRequests",
            //    column: "serviceId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MobRequests_subServiceId",
            //    table: "MobRequests",
            //    column: "subServiceId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MobRequests_MOB_SERVICE_serviceId",
            //    table: "MobRequests",
            //    column: "serviceId",
            //    principalTable: "MOB_SERVICE",
            //    principalColumn: "ServicesId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MobRequests_MOB_SUB_SERVICE_subServiceId",
            //    table: "MobRequests",
            //    column: "subServiceId",
            //    principalTable: "MOB_SUB_SERVICE",
            //    principalColumn: "SubServicesId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_serviceId",
                table: "MobRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MobRequests_MOB_SUB_SERVICE_subServiceId",
                table: "MobRequests");

            migrationBuilder.DropIndex(
                name: "IX_MobRequests_serviceId",
                table: "MobRequests");

            migrationBuilder.DropIndex(
                name: "IX_MobRequests_subServiceId",
                table: "MobRequests");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "MobRequests");

            migrationBuilder.RenameColumn(
                name: "subServiceId",
                table: "MobRequests",
                newName: "SubServicesId1");

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "MobRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubServicesId",
                table: "MobRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MobRequests_ServicesId",
                table: "MobRequests",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_MobRequests_SubServicesId",
                table: "MobRequests",
                column: "SubServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_MOB_SERVICE_ServicesId",
                table: "MobRequests",
                column: "ServicesId",
                principalTable: "MOB_SERVICE",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MobRequests_MOB_SUB_SERVICE_SubServicesId",
                table: "MobRequests",
                column: "SubServicesId",
                principalTable: "MOB_SUB_SERVICE",
                principalColumn: "SubServicesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
