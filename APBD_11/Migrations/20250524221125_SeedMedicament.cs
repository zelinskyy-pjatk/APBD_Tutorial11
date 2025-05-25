using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_11.Migrations
{
    /// <inheritdoc />
    public partial class SeedMedicament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "MedicamentId", "Description", "Name", "Type" },
                values: new object[] { 1, "Take max 1 time daily.", "Ibuprofen ", "Nonsteroidal anti-inflammatory drug (NSAID)" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "MedicamentId",
                keyValue: 1);
        }
    }
}
