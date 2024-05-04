using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSpot.Services.MagorAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpDatFeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityName",
                table: "Majors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniversityName",
                table: "Majors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 1,
                column: "UniversityName",
                value: "Syrian Virtual University");
        }
    }
}
