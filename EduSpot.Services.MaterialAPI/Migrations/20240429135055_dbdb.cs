using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSpot.Services.MaterialAPI.Migrations
{
    /// <inheritdoc />
    public partial class dbdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortCut",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortCut",
                table: "Materials");
        }
    }
}
