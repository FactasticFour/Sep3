using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PersistenceServer.Migrations
{
    public partial class S02InitialCreate_02 : Migration
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
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
                name: "AccountAccount",
                columns: table => new
                {
                    Account1AccountId = table.Column<int>(type: "integer", nullable: false),
                    Account2AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAccount", x => new { x.Account1AccountId, x.Account2AccountId });
                    table.ForeignKey(
                        name: "FK_AccountAccount_Accounts_Account1AccountId",
                        column: x => x.Account1AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAccount_Accounts_Account2AccountId",
                        column: x => x.Account2AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    ViaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CampusCity = table.Column<string>(type: "character varying(256)", nullable: true),
                    CampusStreet = table.Column<string>(type: "character varying(256)", nullable: true),
                    CampusPostCode = table.Column<string>(type: "character varying(4)", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.ViaId);
                    table.ForeignKey(
                        name: "FK_Facilities_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facilities_Campuses_CampusCity_CampusStreet_CampusPostCode",
                        columns: x => new { x.CampusCity, x.CampusStreet, x.CampusPostCode },
                        principalTable: "Campuses",
                        principalColumns: new[] { "City", "Street", "postcode" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facilities_ViaEntity_ViaId",
                        column: x => x.ViaId,
                        principalTable: "ViaEntity",
                        principalColumn: "ViaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ViaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    lname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Cpr = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ViaId);
                    table.ForeignKey(
                        name: "FK_Members_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_ViaEntity_ViaId",
                        column: x => x.ViaId,
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
                name: "IX_AccountAccount_Account2AccountId",
                table: "AccountAccount",
                column: "Account2AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreditCardNumber",
                table: "Accounts",
                column: "CreditCardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_viaId",
                table: "Accounts",
                column: "viaId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_AccountId",
                table: "Facilities",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_CampusCity_CampusStreet_CampusPostCode",
                table: "Facilities",
                columns: new[] { "CampusCity", "CampusStreet", "CampusPostCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Members_AccountId",
                table: "Members",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_accountId",
                table: "Roles",
                column: "accountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAccount");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Campuses");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "ViaEntity");
        }
    }
}
