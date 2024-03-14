using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLab.Repository.Migrations
{
    public partial class Migration_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Song",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Album");
        }
    }
}
