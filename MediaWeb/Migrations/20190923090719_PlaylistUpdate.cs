using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class PlaylistUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SeriePlaylist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PodcastPlaylist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MuziekPlaylist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FilmPlaylist",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SeriePlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PodcastPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MuziekPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FilmPlaylist");
        }
    }
}
