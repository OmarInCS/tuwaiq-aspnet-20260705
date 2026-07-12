using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicApp.Migrations
{
    /// <inheritdoc />
    public partial class SpecialitiesSeddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pediatric" },
                    { 2, "ENT" },
                    { 3, "Cardiology" },
                    { 4, "OB-Obge" }
                });

            migrationBuilder.InsertData(
                table: "DoctorSpecialities",
                columns: new[] { "DoctorId", "SpecialityId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
