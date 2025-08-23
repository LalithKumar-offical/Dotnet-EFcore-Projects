using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class Cascadedelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSeason_DbWebseries_WebseriesInstanceWebseriesId",
                table: "DbSeason");

            migrationBuilder.DropForeignKey(
                name: "FK_DbWebseries_DbDirector_DirectorInstanceDirectorId",
                table: "DbWebseries");

            migrationBuilder.DropIndex(
                name: "IX_DbWebseries_DirectorInstanceDirectorId",
                table: "DbWebseries");

            migrationBuilder.DropIndex(
                name: "IX_DbSeason_WebseriesInstanceWebseriesId",
                table: "DbSeason");

            migrationBuilder.DropColumn(
                name: "DirectorInstanceDirectorId",
                table: "DbWebseries");

            migrationBuilder.DropColumn(
                name: "WebseriesInstanceWebseriesId",
                table: "DbSeason");

            migrationBuilder.AlterColumn<string>(
                name: "DirectorId",
                table: "DbWebseries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WebseriesId",
                table: "DbSeason",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S101",
                column: "SeasonPhoto",
                value: "/Images/moneyheist_s1.jpg");

            migrationBuilder.UpdateData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S102",
                column: "SeasonPhoto",
                value: "/Images/moneyheist_s2.jpg");

            migrationBuilder.UpdateData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S201",
                column: "SeasonPhoto",
                value: "/Images/dark_s1.jpg");

            migrationBuilder.UpdateData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S301",
                column: "SeasonPhoto",
                value: "/Images/hanuman_s1.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_DbWebseries_DirectorId",
                table: "DbWebseries",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSeason_WebseriesId",
                table: "DbSeason",
                column: "WebseriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSeason_DbWebseries_WebseriesId",
                table: "DbSeason",
                column: "WebseriesId",
                principalTable: "DbWebseries",
                principalColumn: "WebseriesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbWebseries_DbDirector_DirectorId",
                table: "DbWebseries",
                column: "DirectorId",
                principalTable: "DbDirector",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSeason_DbWebseries_WebseriesId",
                table: "DbSeason");

            migrationBuilder.DropForeignKey(
                name: "FK_DbWebseries_DbDirector_DirectorId",
                table: "DbWebseries");

            migrationBuilder.DropIndex(
                name: "IX_DbWebseries_DirectorId",
                table: "DbWebseries");

            migrationBuilder.DropIndex(
                name: "IX_DbSeason_WebseriesId",
                table: "DbSeason");

            migrationBuilder.AlterColumn<string>(
                name: "DirectorId",
                table: "DbWebseries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "DirectorInstanceDirectorId",
                table: "DbWebseries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WebseriesId",
                table: "DbSeason",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebseriesInstanceWebseriesId",
                table: "DbSeason",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S101",
                columns: new[] { "SeasonPhoto", "WebseriesInstanceWebseriesId" },
                values: new object[] { "moneyheist_s1.jpg", null });

            migrationBuilder.UpdateData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S102",
                columns: new[] { "SeasonPhoto", "WebseriesInstanceWebseriesId" },
                values: new object[] { "moneyheist_s2.jpg", null });

            migrationBuilder.UpdateData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S201",
                columns: new[] { "SeasonPhoto", "WebseriesInstanceWebseriesId" },
                values: new object[] { "dark_s1.jpg", null });

            migrationBuilder.UpdateData(
                table: "DbSeason",
                keyColumn: "SeasonId",
                keyValue: "S301",
                columns: new[] { "SeasonPhoto", "WebseriesInstanceWebseriesId" },
                values: new object[] { "hanuman_s1.jpg", null });

            migrationBuilder.UpdateData(
                table: "DbWebseries",
                keyColumn: "WebseriesId",
                keyValue: "Web_101",
                column: "DirectorInstanceDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DbWebseries",
                keyColumn: "WebseriesId",
                keyValue: "Web_102",
                column: "DirectorInstanceDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DbWebseries",
                keyColumn: "WebseriesId",
                keyValue: "Web_103",
                column: "DirectorInstanceDirectorId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_DbWebseries_DirectorInstanceDirectorId",
                table: "DbWebseries",
                column: "DirectorInstanceDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSeason_WebseriesInstanceWebseriesId",
                table: "DbSeason",
                column: "WebseriesInstanceWebseriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSeason_DbWebseries_WebseriesInstanceWebseriesId",
                table: "DbSeason",
                column: "WebseriesInstanceWebseriesId",
                principalTable: "DbWebseries",
                principalColumn: "WebseriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbWebseries_DbDirector_DirectorInstanceDirectorId",
                table: "DbWebseries",
                column: "DirectorInstanceDirectorId",
                principalTable: "DbDirector",
                principalColumn: "DirectorId");
        }
    }
}
