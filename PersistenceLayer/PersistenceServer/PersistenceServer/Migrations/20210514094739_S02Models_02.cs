using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceServer.Migrations
{
    public partial class S02Models_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeCity",
                table: "Facilities",
                type: "character varying(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypePostCode",
                table: "Facilities",
                type: "character varying(4)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeStreet",
                table: "Facilities",
                type: "character varying(256)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_TypeCity_TypeStreet_TypePostCode",
                table: "Facilities",
                columns: new[] { "TypeCity", "TypeStreet", "TypePostCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Campuses_TypeCity_TypeStreet_TypePostCode",
                table: "Facilities",
                columns: new[] { "TypeCity", "TypeStreet", "TypePostCode" },
                principalTable: "Campuses",
                principalColumns: new[] { "City", "Street", "postcode" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Campuses_TypeCity_TypeStreet_TypePostCode",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_TypeCity_TypeStreet_TypePostCode",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "TypeCity",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "TypePostCode",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "TypeStreet",
                table: "Facilities");
        }
    }
}
