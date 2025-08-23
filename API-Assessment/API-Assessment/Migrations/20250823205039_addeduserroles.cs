using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class addeduserroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "DbUser",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DbUser",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserRole",
                value: null);

            migrationBuilder.UpdateData(
                table: "DbUser",
                keyColumn: "UserId",
                keyValue: 2,
                column: "UserRole",
                value: null);

            migrationBuilder.UpdateData(
                table: "DbUser",
                keyColumn: "UserId",
                keyValue: 3,
                column: "UserRole",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "DbUser");
        }
    }
}
