using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bc2b673-756f-426b-8434-5301c519230f", "0bc2b673-756f-426b-8434-5301c519230f", "APP_ADMIN", "APP_ADMIN" },
                    { "0bc2b673-756f-426b-8435-5301c519230f", "0bc2b673-756f-426b-8435-5301c519230f", "DOCTOR", "DOCTOR" },
                    { "0bc2b673-756f-426b-8436-5301c519230f", "0bc2b673-756f-426b-8436-5301c519230f", "OFFICER", "OFFICER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0bc2b673-756f-426b-8434-5301c519230f");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0bc2b673-756f-426b-8435-5301c519230f");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0bc2b673-756f-426b-8436-5301c519230f");
        }
    }
}
