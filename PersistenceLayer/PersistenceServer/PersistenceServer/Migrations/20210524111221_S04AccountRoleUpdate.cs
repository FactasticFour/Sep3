using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PersistenceServer.Migrations
{
    public partial class S04AccountRoleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Accounts_AccountId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Accounts_AccountId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Accounts_accountId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "AccountAccount");

            migrationBuilder.DropIndex(
                name: "IX_Roles_accountId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Members_AccountId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_AccountId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "accountId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Facilities");

            migrationBuilder.AddColumn<int>(
                name: "accountId",
                table: "ViaEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "AmountOfMoney",
                table: "CreditCards",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                table: "Accounts",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Accounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    receiver = table.Column<int>(type: "integer", nullable: false),
                    sender = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_receiver",
                        column: x => x.receiver,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_sender",
                        column: x => x.sender,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViaEntity_accountId",
                table: "ViaEntity",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_type",
                table: "Accounts",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_receiver",
                table: "Transactions",
                column: "receiver");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_sender",
                table: "Transactions",
                column: "sender");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_type",
                table: "Accounts",
                column: "type",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViaEntity_Accounts_accountId",
                table: "ViaEntity",
                column: "accountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_type",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ViaEntity_Accounts_accountId",
                table: "ViaEntity");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_ViaEntity_accountId",
                table: "ViaEntity");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_type",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "accountId",
                table: "ViaEntity");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "accountId",
                table: "Roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Facilities",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AmountOfMoney",
                table: "CreditCards",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Accounts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "AccountAccount",
                columns: table => new
                {
                    ReceiverAccountId = table.Column<int>(type: "integer", nullable: false),
                    SenderAccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAccount", x => new { x.ReceiverAccountId, x.SenderAccountId });
                    table.ForeignKey(
                        name: "FK_AccountAccount_Accounts_ReceiverAccountId",
                        column: x => x.ReceiverAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAccount_Accounts_SenderAccountId",
                        column: x => x.SenderAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_accountId",
                table: "Roles",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_AccountId",
                table: "Members",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_AccountId",
                table: "Facilities",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAccount_SenderAccountId",
                table: "AccountAccount",
                column: "SenderAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Accounts_AccountId",
                table: "Facilities",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Accounts_AccountId",
                table: "Members",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Accounts_accountId",
                table: "Roles",
                column: "accountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
