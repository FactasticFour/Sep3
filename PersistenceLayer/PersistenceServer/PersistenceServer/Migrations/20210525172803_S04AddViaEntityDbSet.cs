using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceServer.Migrations
{
    public partial class S04AddViaEntityDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_ViaEntity_viaId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_ViaEntity_ViaId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_ViaEntity_ViaId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_ViaEntity_Accounts_accountId",
                table: "ViaEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ViaEntity",
                table: "ViaEntity");

            migrationBuilder.RenameTable(
                name: "ViaEntity",
                newName: "ViaEntities");

            migrationBuilder.RenameIndex(
                name: "IX_ViaEntity_accountId",
                table: "ViaEntities",
                newName: "IX_ViaEntities_accountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ViaEntities",
                table: "ViaEntities",
                column: "ViaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_ViaEntities_viaId",
                table: "Accounts",
                column: "viaId",
                principalTable: "ViaEntities",
                principalColumn: "ViaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_ViaEntities_ViaId",
                table: "Facilities",
                column: "ViaId",
                principalTable: "ViaEntities",
                principalColumn: "ViaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_ViaEntities_ViaId",
                table: "Members",
                column: "ViaId",
                principalTable: "ViaEntities",
                principalColumn: "ViaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViaEntities_Accounts_accountId",
                table: "ViaEntities",
                column: "accountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_ViaEntities_viaId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_ViaEntities_ViaId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_ViaEntities_ViaId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_ViaEntities_Accounts_accountId",
                table: "ViaEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ViaEntities",
                table: "ViaEntities");

            migrationBuilder.RenameTable(
                name: "ViaEntities",
                newName: "ViaEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ViaEntities_accountId",
                table: "ViaEntity",
                newName: "IX_ViaEntity_accountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ViaEntity",
                table: "ViaEntity",
                column: "ViaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_ViaEntity_viaId",
                table: "Accounts",
                column: "viaId",
                principalTable: "ViaEntity",
                principalColumn: "ViaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_ViaEntity_ViaId",
                table: "Facilities",
                column: "ViaId",
                principalTable: "ViaEntity",
                principalColumn: "ViaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_ViaEntity_ViaId",
                table: "Members",
                column: "ViaId",
                principalTable: "ViaEntity",
                principalColumn: "ViaId",
                onDelete: ReferentialAction.Cascade);

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
