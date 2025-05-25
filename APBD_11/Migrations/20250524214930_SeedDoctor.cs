using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_11.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "daniel.saga@gmail.com", "Daniel", "Saga" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 1);
        }
    }
}
