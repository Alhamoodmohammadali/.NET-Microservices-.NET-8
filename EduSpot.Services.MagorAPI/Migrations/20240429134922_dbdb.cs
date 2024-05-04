using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduSpot.Services.MagorAPI.Migrations
{
    /// <inheritdoc />
    public partial class dbdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 1,
                columns: new[] { "ImageUrl", "UniversityId" },
                values: new object[] { "https://placehold.co/603x403", 1 });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "ArbicName", "CountHours", "Description", "ImageLocalPath", "ImageUrl", "Name", "PdfLocalPath", "PdfUrl", "ShortCut", "UniversityId" },
                values: new object[,]
                {
                    { 2, "معهد التقاني للحاسوب ", 60, "allowing students to study at any time and from anywhere that suits them.\r\n                                The university also focuses on providing excellent technical and academic \r\n                                support to students to ensure their academic success\r\n                ", null, "https://placehold.co/603x403", "Tincncal Iinternal City", null, null, "TIC", 1 },
                    { 3, "كلية التقاني للحاسوب ", 120, "allowing students to study at any time and from anywhere that suits them.\r\n                                The university also focuses on providing excellent technical and academic \r\n                                support to students to ensure their academic success", null, "https://placehold.co/603x403", "B incncal Binternal Bity", null, null, "Bait ", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 1,
                columns: new[] { "ImageUrl", "UniversityId" },
                values: new object[] { null, 0 });
        }
    }
}
