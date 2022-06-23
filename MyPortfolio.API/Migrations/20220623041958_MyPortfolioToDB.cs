using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.API.Migrations
{
    public partial class MyPortfolioToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    ContactNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SkypeId = table.Column<string>(type: "TEXT", nullable: false),
                    Linkedin = table.Column<string>(type: "TEXT", nullable: false),
                    Twitter = table.Column<string>(type: "TEXT", nullable: false),
                    Others = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsActive = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioType",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsActive = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsActive = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioSummary",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PortfolioID = table.Column<long>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ShortTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsActive = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioSummary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PortfolioSummary_Portfolio_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ContactNumber",
                table: "Portfolio",
                column: "ContactNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_Email",
                table: "Portfolio",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_IsActive",
                table: "Portfolio",
                column: "IsActive",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_Linkedin",
                table: "Portfolio",
                column: "Linkedin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_Name",
                table: "Portfolio",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_SkypeId",
                table: "Portfolio",
                column: "SkypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_Twitter",
                table: "Portfolio",
                column: "Twitter",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSummary_IsActive",
                table: "PortfolioSummary",
                column: "IsActive",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSummary_PortfolioID",
                table: "PortfolioSummary",
                column: "PortfolioID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSummary_ShortTitle",
                table: "PortfolioSummary",
                column: "ShortTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSummary_Summary",
                table: "PortfolioSummary",
                column: "Summary",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSummary_Title",
                table: "PortfolioSummary",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioType_IsActive",
                table: "PortfolioType",
                column: "IsActive",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioType_Type",
                table: "PortfolioType",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_Description",
                table: "Skill",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_IsActive",
                table: "Skill",
                column: "IsActive",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_Name",
                table: "Skill",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioSummary");

            migrationBuilder.DropTable(
                name: "PortfolioType");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Portfolio");
        }
    }
}
