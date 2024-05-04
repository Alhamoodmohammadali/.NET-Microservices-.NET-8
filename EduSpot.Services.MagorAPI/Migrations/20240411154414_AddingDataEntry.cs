using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSpot.Services.MagorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "ArbicName", "CountHours", "Description", "ImageLocalPath", "ImageUrl", "Name", "PdfLocalPath", "PdfUrl", "ShortCut", "UniversityId", "UniversityName" },
                values: new object[] { 1, "Name", 1, "Description", null, null, "Name", null, null, "dsdssd", 0, "Syrian Virtual University" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 1);
        }
    }
}
