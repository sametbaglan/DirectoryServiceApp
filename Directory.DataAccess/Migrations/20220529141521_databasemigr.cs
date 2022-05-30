using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Directory.DataAccess.Migrations
{
    public partial class databasemigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoType",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Delete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Company = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Delete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    infotypeid = table.Column<int>(type: "integer", nullable: false),
                    InfoContent = table.Column<string>(type: "text", nullable: true),
                    personid = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Delete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.id);
                    table.ForeignKey(
                        name: "FK_ContactInformation_InfoType_infotypeid",
                        column: x => x.infotypeid,
                        principalTable: "InfoType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactInformation_Persons_personid",
                        column: x => x.personid,
                        principalTable: "Persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    zipcode = table.Column<string>(type: "text", nullable: true),
                    County = table.Column<string>(type: "text", nullable: true),
                    street = table.Column<string>(type: "text", nullable: true),
                    contactinformationid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                    table.ForeignKey(
                        name: "FK_Location_ContactInformation_contactinformationid",
                        column: x => x.contactinformationid,
                        principalTable: "ContactInformation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_infotypeid",
                table: "ContactInformation",
                column: "infotypeid");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_personid",
                table: "ContactInformation",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_Location_contactinformationid",
                table: "Location",
                column: "contactinformationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "ContactInformation");

            migrationBuilder.DropTable(
                name: "InfoType");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
