using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSpot.Services.MagorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArbicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountHours = table.Column<int>(type: "int", nullable: false),
                    ShortCut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
