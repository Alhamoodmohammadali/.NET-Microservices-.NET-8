using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSpot.Services.CourcesAPI.Migrations
{
    /// <inheritdoc />
    public partial class dbcond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_video_CourseId",
                table: "video",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_video_Cources_CourseId",
                table: "video",
                column: "CourseId",
                principalTable: "Cources",
                principalColumn: "CourceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_Cources_CourseId",
                table: "video");

            migrationBuilder.DropIndex(
                name: "IX_video_CourseId",
                table: "video");
        }
    }
}
