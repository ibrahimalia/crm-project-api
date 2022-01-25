using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class RebuildRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AlterColumn<long>(
                name: "AccountsId",
                table: "FeedBacks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MobRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),

                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobRequests_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MobRequests_MOB_MERCHANT_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobRequests_AccountsId",
                table: "MobRequests",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_MobRequests_MerchantId",
                table: "MobRequests",
                column: "MerchantId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FeedBacks_Accounts_AccountsId",
            //    table: "FeedBacks",
            //    column: "AccountsId",
            //    principalTable: "Accounts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Accounts_AccountsId",
                table: "FeedBacks");

            migrationBuilder.DropTable(
                name: "MobRequests");

            migrationBuilder.AlterColumn<long>(
                name: "AccountsId",
                table: "FeedBacks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ClientId",
                table: "FeedBacks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Accounts_AccountsId",
                table: "FeedBacks",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
