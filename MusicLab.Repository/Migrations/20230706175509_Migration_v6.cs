using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLab.Repository.Migrations
{
    public partial class Migration_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Artist");
        }
    }
}
