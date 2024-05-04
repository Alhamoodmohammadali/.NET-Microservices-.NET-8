using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSpot.Services.CourcesAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbCOnerte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Cources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "video",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video", x => x.VideoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cources_CategoryId",
                table: "Cources",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cources_categories_CategoryId",
                table: "Cources",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cources_categories_CategoryId",
                table: "Cources");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "video");

            migrationBuilder.DropIndex(
                name: "IX_Cources_CategoryId",
                table: "Cources");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Cources");
        }
    }
}
