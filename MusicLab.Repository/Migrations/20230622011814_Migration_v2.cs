using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLab.Repository.Migrations
{
    public partial class Migration_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artist_ArtistId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourite_Songs_SongId",
                table: "Favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayHistory_Songs_SongId",
                table: "PlayHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Songs_SongId",
                table: "PlaylistSong");

            migrationBuilder.DropForeignKey(
                name: "FK_SongCategories_Categories_CategoryId",
                table: "SongCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SongCategories_Songs_SongId",
                table: "SongCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongCategories",
                table: "SongCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Song");

            migrationBuilder.RenameTable(
                name: "SongCategories",
                newName: "SongCategory");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_AlbumId",
                table: "Song",
                newName: "IX_Song_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_SongCategories_CategoryId",
                table: "SongCategory",
                newName: "IX_SongCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_ArtistId",
                table: "Album",
                newName: "IX_Album_ArtistId");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Song",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongCategory",
                table: "SongCategory",
                columns: new[] { "SongId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourite_Song_SongId",
                table: "Favourite",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayHistory_Song_SongId",
                table: "PlayHistory",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Song_SongId",
                table: "PlaylistSong",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongCategory_Category_CategoryId",
                table: "SongCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongCategory_Song_SongId",
                table: "SongCategory",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourite_Song_SongId",
                table: "Favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayHistory_Song_SongId",
                table: "PlayHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Song_SongId",
                table: "PlaylistSong");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_SongCategory_Category_CategoryId",
                table: "SongCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SongCategory_Song_SongId",
                table: "SongCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongCategory",
                table: "SongCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "SongCategory",
                newName: "SongCategories");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Songs");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_SongCategory_CategoryId",
                table: "SongCategories",
                newName: "IX_SongCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_AlbumId",
                table: "Songs",
                newName: "IX_Songs_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Album_ArtistId",
                table: "Albums",
                newName: "IX_Albums_ArtistId");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongCategories",
                table: "SongCategories",
                columns: new[] { "SongId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artist_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourite_Songs_SongId",
                table: "Favourite",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayHistory_Songs_SongId",
                table: "PlayHistory",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Songs_SongId",
                table: "PlaylistSong",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongCategories_Categories_CategoryId",
                table: "SongCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongCategories_Songs_SongId",
                table: "SongCategories",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
