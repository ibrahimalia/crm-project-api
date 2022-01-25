using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class repaireTimeSheetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "PRJTimeSheet",
                newName: "ToTime");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "PRJTimeSheet",
                newName: "FromTime");

            migrationBuilder.AddColumn<string>(
                name: "MerchantID",
                table: "PRJTimeSheet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRJTimeSheet_MerchantID",
                table: "PRJTimeSheet",
                column: "MerchantID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRJTimeSheet_MOB_MERCHANT_MerchantID",
                table: "PRJTimeSheet",
                column: "MerchantID",
                principalTable: "MOB_MERCHANT",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRJTimeSheet_MOB_MERCHANT_MerchantID",
                table: "PRJTimeSheet");

            migrationBuilder.DropIndex(
                name: "IX_PRJTimeSheet_MerchantID",
                table: "PRJTimeSheet");

            migrationBuilder.DropColumn(
                name: "MerchantID",
                table: "PRJTimeSheet");

            migrationBuilder.RenameColumn(
                name: "ToTime",
                table: "PRJTimeSheet",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "FromTime",
                table: "PRJTimeSheet",
                newName: "From");
        }
    }
}
