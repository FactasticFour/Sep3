using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceServer.Migrations
{
    public partial class S04ViaEntityRequiredAccountUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViaEntity_Accounts_accountId",
                table: "ViaEntity");

            migrationBuilder.AlterColumn<int>(
                name: "accountId",
                table: "ViaEntity",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ViaEntity_Accounts_accountId",
                table: "ViaEntity",
                column: "accountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViaEntity_Accounts_accountId",
                table: "ViaEntity");

            migrationBuilder.AlterColumn<int>(
                name: "accountId",
                table: "ViaEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ViaEntity_Accounts_accountId",
                table: "ViaEntity",
                column: "accountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
