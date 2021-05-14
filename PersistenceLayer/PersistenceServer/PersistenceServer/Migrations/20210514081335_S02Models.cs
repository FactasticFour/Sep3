using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PersistenceServer.Migrations
{
    public partial class S02Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campuses",
                columns: table => new
                {
                    City = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Street = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    postcode = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => new { x.City, x.Street, x.postcode });
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditCardNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    fname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    lname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExpirationMonth = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ExpirationYear = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    SecurityCode = table.Column<int>(type: "integer", nullable: false),
                    AmountOfMoney = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditCardNumber);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    SenderViaId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverViaId = table.Column<int>(type: "integer", nullable: false),
                    transferAmount = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => new { x.ReceiverViaId, x.SenderViaId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ViaEntity",
                columns: table => new
                {
                    ViaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Facility_Password = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Street = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    postcode = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    fname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    lname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Cpr = table.Column<int>(type: "integer", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaEntity", x => x.ViaId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationPassword = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<int>(type: "integer", nullable: false),
                    viaId = table.Column<int>(type: "integer", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "character varying(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_CreditCards_CreditCardNumber",
                        column: x => x.CreditCardNumber,
                        principalTable: "CreditCards",
                        principalColumn: "CreditCardNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_ViaEntity_viaId",
                        column: x => x.viaId,
                        principalTable: "ViaEntity",
                        principalColumn: "ViaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    accountId = table.Column<int>(type: "integer", nullable: false),
                    RoleType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreditCardNumber",
                table: "Accounts",
                column: "CreditCardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_viaId",
                table: "Accounts",
                column: "viaId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_accountId",
                table: "Roles",
                column: "accountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campuses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "ViaEntity");
        }
    }
}
