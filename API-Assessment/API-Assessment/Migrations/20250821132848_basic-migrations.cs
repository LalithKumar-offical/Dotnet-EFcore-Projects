using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class basicmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbDirector",
                columns: table => new
                {
                    DirectorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DirectorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorAge = table.Column<int>(type: "int", nullable: true),
                    DirectorEmail = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DirectorPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorExperience = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDirector", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "DbUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserAdult = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DbWebseries",
                columns: table => new
                {
                    WebseriesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WebseriesTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebseriesDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WebseriesType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WebseriesAgerestrictions = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DirectorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorInstanceDirectorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbWebseries", x => x.WebseriesId);
                    table.ForeignKey(
                        name: "FK_DbWebseries_DbDirector_DirectorInstanceDirectorId",
                        column: x => x.DirectorInstanceDirectorId,
                        principalTable: "DbDirector",
                        principalColumn: "DirectorId");
                });

            migrationBuilder.CreateTable(
                name: "DbRating",
                columns: table => new
                {
                    RatingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RatingNo = table.Column<int>(type: "int", nullable: true),
                    RatingComment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RatingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WebseriesId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebseriesInstanceWebseriesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInstanceUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbRating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_DbRating_DbUser_UserInstanceUserId",
                        column: x => x.UserInstanceUserId,
                        principalTable: "DbUser",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_DbRating_DbWebseries_WebseriesInstanceWebseriesId",
                        column: x => x.WebseriesInstanceWebseriesId,
                        principalTable: "DbWebseries",
                        principalColumn: "WebseriesId");
                });

            migrationBuilder.CreateTable(
                name: "DbSeason",
                columns: table => new
                {
                    SeasonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeasonPhoto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    WebseriesId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebseriesInstanceWebseriesId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSeason", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_DbSeason_DbWebseries_WebseriesInstanceWebseriesId",
                        column: x => x.WebseriesInstanceWebseriesId,
                        principalTable: "DbWebseries",
                        principalColumn: "WebseriesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbRating_UserInstanceUserId",
                table: "DbRating",
                column: "UserInstanceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbRating_WebseriesInstanceWebseriesId",
                table: "DbRating",
                column: "WebseriesInstanceWebseriesId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSeason_WebseriesInstanceWebseriesId",
                table: "DbSeason",
                column: "WebseriesInstanceWebseriesId");

            migrationBuilder.CreateIndex(
                name: "IX_DbWebseries_DirectorInstanceDirectorId",
                table: "DbWebseries",
                column: "DirectorInstanceDirectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbRating");

            migrationBuilder.DropTable(
                name: "DbSeason");

            migrationBuilder.DropTable(
                name: "DbUser");

            migrationBuilder.DropTable(
                name: "DbWebseries");

            migrationBuilder.DropTable(
                name: "DbDirector");
        }
    }
}
