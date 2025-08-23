using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class seedingandautomaticdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "WebseriesDate",
                table: "DbWebseries",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "RatingDate",
                table: "DbRating",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "DbDirector",
                columns: new[] { "DirectorId", "DirectorAge", "DirectorEmail", "DirectorExperience", "DirectorName", "DirectorPassword" },
                values: new object[,]
                {
                    { "Dir_101", 45, "alexpina@gmail.com", "21", "Alex Pina", "alexpina" },
                    { "Dir_102", 42, "baranboodar@gmail.com", "17", "Baran Bo Odar", "baranboodar" },
                    { "Dir_103", 50, "sharaddevarajan@gmail.com", "27", "Sharad Devarajan", "sharaddevarajan" },
                    { "Dir_104", 55, "christophernolan@gmail.com", "32", "Christopher Nolan", "christopher" }
                });

            migrationBuilder.InsertData(
                table: "DbRating",
                columns: new[] { "RatingId", "RatingComment", "RatingNo", "UserId", "UserInstanceUserId", "WebseriesId", "WebseriesInstanceWebseriesId" },
                values: new object[,]
                {
                    { "R101", "Amazing!", 5, "1", null, "Web_101", null },
                    { "R102", "Mind-blowing", 4, "2", null, "Web_102", null },
                    { "R103", "Good animation", 3, "3", null, "Web_103", null }
                });

            migrationBuilder.InsertData(
                table: "DbSeason",
                columns: new[] { "SeasonId", "SeasonPhoto", "WebseriesId", "WebseriesInstanceWebseriesId" },
                values: new object[,]
                {
                    { "S101", "moneyheist_s1.jpg", "Web_101", null },
                    { "S102", "moneyheist_s2.jpg", "Web_101", null },
                    { "S201", "dark_s1.jpg", "Web_102", null },
                    { "S301", "hanuman_s1.jpg", "Web_103", null }
                });

            migrationBuilder.InsertData(
                table: "DbUser",
                columns: new[] { "UserId", "UserAdult", "UserEmail", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 1, true, "lalith@gmail.com", "Lalith", "lalith" },
                    { 2, true, "hadiya@gmail.com", "Hadiya", "hadiya" },
                    { 3, false, "Reshni@gmail.com", "Reshni", "Reshni" }
                });

            migrationBuilder.InsertData(
                table: "DbWebseries",
                columns: new[] { "WebseriesId", "DirectorId", "DirectorInstanceDirectorId", "WebseriesAgerestrictions", "WebseriesTitle", "WebseriesType" },
                values: new object[,]
                {
                    { "Web_101", "Dir_101", null, "18+", "Money Heist", "Thriller" },
                    { "Web_102", "Dir_102", null, "16+", "Dark", "Sci-Fi" },
                    { "Web_103", "Dir_103", null, "7+", "The Legend of Hanuman", "Mythology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DbDirector",
                keyColumn: "DirectorId",
                keyValue: "Dir_101");

            migrationBuilder.DeleteData(
                table: "DbDirector",
                keyColumn: "DirectorId",
                keyValue: "Dir_102");

            migrationBuilder.DeleteData(
                table: "DbDirector",
                keyColumn: "DirectorId",
                keyValue: "Dir_103");

            migrationBuilder.DeleteData(
                table: "DbDirector",
                keyColumn: "DirectorId",
                keyValue: "Dir_104");

            migrationBuilder.DeleteData(
                table: "DbRating",
                keyColumn: "RatingId",
                keyValue: "R101");

            migrationBuilder.DeleteData(
                table: "DbRating",
                keyColumn: "RatingId",
                keyValue: "R102");

            migrationBuilder.DeleteData(
                table: "DbRating",
                keyColumn: "RatingId",
                keyValue: "R103");

            migrationBuilder.DeleteData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S101");

            migrationBuilder.DeleteData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S102");

            migrationBuilder.DeleteData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S201");

            migrationBuilder.DeleteData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S301");

            migrationBuilder.DeleteData(
                table: "DbUser",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DbUser",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DbUser",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DbWebseries",
                keyColumn: "WebseriesId",
                keyValue: "Web_101");

            migrationBuilder.DeleteData(
                table: "DbWebseries",
                keyColumn: "WebseriesId",
                keyValue: "Web_102");

            migrationBuilder.DeleteData(
                table: "DbWebseries",
                keyColumn: "WebseriesId",
                keyValue: "Web_103");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "WebseriesDate",
                table: "DbWebseries",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "RatingDate",
                table: "DbRating",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "getdate()");
        }
    }
}
