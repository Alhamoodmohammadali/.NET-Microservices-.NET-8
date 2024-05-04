using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduSpot.Services.UniversityAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "UniversityId", "Description", "ImageLocalPath", "ImageUrl", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "The Syrian Virtual University is distinguished by offering flexible  \r\n                                    and accessible online academic programs, \r\n                                    allowing students to study at any time and from anywhere that suits them.\r\n                                    The university also focuses on providing excellent technical and academic \r\n                                    support to students to ensure their academic success.\\r\\n", null, "https://placehold.co/603x403", "Syrian", "Syrian Virtual University" },
                    { 2, "Damascus International University is considered one of the leading universities in Syria,\\n\r\n                                    providing high-quality education in a variety of academic disciplines.\\n\r\n                                    The university aims to develop students' skills and enhance their capabilities \\n\r\n                                    through comprehensive academic programs and updated curricula that meet the needs of the job market.\\n\r\n                                    The university is characterized by a modern academic environment and advanced facilities that facilitate\\n\r\n                                    the learning process and motivate students to achieve their academic and professional goals.\\n", null, "https://placehold.co/603x403", "Damascus", "Damascus International University" },
                    { 3, "The Syrian Private University is considered a prestigious educational destination in Syria, \\n\r\n                                   providing a distinctive learning environment that helps students achieve their academic and professional goals. \\n\r\n                                   The university is known for offering diverse academic programs covering a wide range of specialties, \\n\r\n                                   allowing students to choose the field that suits their interests and professional inclinations. Additionally,\\n\r\n                                   the university provides modern infrastructure and educational facilities equipped with the latest technologies,\\n\r\n                                   which help enhance the learning process and develop students' skills effectively", null, "https://placehold.co/603x403", "Damascus", "Syrian Private University" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "UniversityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "UniversityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "UniversityId",
                keyValue: 3);
        }
    }
}
