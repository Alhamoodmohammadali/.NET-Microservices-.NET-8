using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSpot.Services.CourcesAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cources",
                columns: table => new
                {
                    CourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoURl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cources", x => x.CourceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cources");
        }
    }
}
