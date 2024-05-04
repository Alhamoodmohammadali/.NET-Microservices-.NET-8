using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSpot.Services.MagorAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 1,
                columns: new[] { "ArbicName", "CountHours", "Description", "Name", "ShortCut" },
                values: new object[] { "معهد التقاني للحاسوب ", 60, "allowing students to study at any time and from anywhere that suits them.\r\n                                The university also focuses on providing excellent technical and academic \r\n                                support to students to ensure their academic success\r\n                ", "Tincncal Iinternal City", "TIC" });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 2,
                columns: new[] { "ArbicName", "CountHours", "Description", "Name", "ShortCut" },
                values: new object[] { "كلية التقاني للحاسوب ", 120, "allowing students to study at any time and from anywhere that suits them.\r\n                                The university also focuses on providing excellent technical and academic \r\n                                support to students to ensure their academic success", "B incncal Binternal Bity", "Bait " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 1,
                columns: new[] { "ArbicName", "CountHours", "Description", "Name", "ShortCut" },
                values: new object[] { "Name", 1, "Description", "Name", "dsdssd" });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 2,
                columns: new[] { "ArbicName", "CountHours", "Description", "Name", "ShortCut" },
                values: new object[] { "معهد التقاني للحاسوب ", 60, "allowing students to study at any time and from anywhere that suits them.\r\n                                The university also focuses on providing excellent technical and academic \r\n                                support to students to ensure their academic success\r\n                ", "Tincncal Iinternal City", "TIC" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "ArbicName", "CountHours", "Description", "ImageLocalPath", "ImageUrl", "Name", "PdfLocalPath", "PdfUrl", "ShortCut", "UniversityId" },
                values: new object[] { 3, "كلية التقاني للحاسوب ", 120, "allowing students to study at any time and from anywhere that suits them.\r\n                                The university also focuses on providing excellent technical and academic \r\n                                support to students to ensure their academic success", null, "https://placehold.co/603x403", "B incncal Binternal Bity", null, null, "Bait ", 1 });
        }
    }
}
