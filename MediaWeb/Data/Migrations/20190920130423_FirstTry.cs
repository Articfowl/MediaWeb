using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Data.Migrations
{
    public partial class FirstTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Lengte = table.Column<int>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false),
                    Foto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmPlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmRegisseur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmRegisseur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuziekAlbum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuziekAlbum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuziekArtiest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuziekArtiest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuziekGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuziekGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuziekPlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuziekPlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Auteur = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastPlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastPlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerieGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriePlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriePlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmRatingReview",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmRatingReview", x => new { x.FilmId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FilmRatingReview_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmRatingReview_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFilmFavourite",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilmFavourite", x => new { x.FilmId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserFilmFavourite_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreFilm",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreFilm", x => new { x.FilmId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GenreFilm_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreFilm_FilmGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "FilmGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFilmPlaylist",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FilmId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilmPlaylist", x => new { x.UserId, x.PlaylistId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_UserFilmPlaylist_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFilmPlaylist_FilmPlaylist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "FilmPlaylist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFilmPlaylist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisseurFilm",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    RegisseurId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisseurFilm", x => new { x.FilmId, x.RegisseurId });
                    table.ForeignKey(
                        name: "FK_RegisseurFilm_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisseurFilm_FilmRegisseur_RegisseurId",
                        column: x => x.RegisseurId,
                        principalTable: "FilmRegisseur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nummer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Lengte = table.Column<int>(nullable: false),
                    ArtiestId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false),
                    Zichtbaar = table.Column<bool>(nullable: false),
                    AlbumArt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nummer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nummer_MuziekAlbum_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "MuziekAlbum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nummer_MuziekArtiest_ArtiestId",
                        column: x => x.ArtiestId,
                        principalTable: "MuziekArtiest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastEpisode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Lengte = table.Column<int>(nullable: false),
                    PodcastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastEpisode_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genre = table.Column<string>(nullable: true),
                    PodcastId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastGenre_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SerieEpisode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Lengte = table.Column<int>(nullable: false),
                    SerieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerieEpisode_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSerie",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSerie", x => new { x.GenreId, x.SerieId });
                    table.ForeignKey(
                        name: "FK_GenreSerie_SerieGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "SerieGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSerie_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMuziek",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    MuziekId = table.Column<int>(nullable: false),
                    NummerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMuziek", x => new { x.GenreId, x.MuziekId });
                    table.ForeignKey(
                        name: "FK_GenreMuziek_MuziekGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "MuziekGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMuziek_Nummer_NummerId",
                        column: x => x.NummerId,
                        principalTable: "Nummer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MuziekRatingReview",
                columns: table => new
                {
                    MuziekId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    NummerId = table.Column<int>(nullable: true),
                    Review = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuziekRatingReview", x => new { x.UserId, x.MuziekId });
                    table.ForeignKey(
                        name: "FK_MuziekRatingReview_Nummer_NummerId",
                        column: x => x.NummerId,
                        principalTable: "Nummer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MuziekRatingReview_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMuziekFavourite",
                columns: table => new
                {
                    MuziekId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    NummerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMuziekFavourite", x => new { x.MuziekId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMuziekFavourite_Nummer_NummerId",
                        column: x => x.NummerId,
                        principalTable: "Nummer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMuziekFavourite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMuziekPlaylist",
                columns: table => new
                {
                    MuziekId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    NummerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMuziekPlaylist", x => new { x.UserId, x.PlaylistId, x.MuziekId });
                    table.ForeignKey(
                        name: "FK_UserMuziekPlaylist_Nummer_NummerId",
                        column: x => x.NummerId,
                        principalTable: "Nummer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMuziekPlaylist_MuziekPlaylist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "MuziekPlaylist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMuziekPlaylist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastRatingReview",
                columns: table => new
                {
                    PodcastEpisodeId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastRatingReview", x => new { x.PodcastEpisodeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PodcastRatingReview_PodcastEpisode_PodcastEpisodeId",
                        column: x => x.PodcastEpisodeId,
                        principalTable: "PodcastEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastRatingReview_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPodcastFavourite",
                columns: table => new
                {
                    PodcastEpisodeId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPodcastFavourite", x => new { x.UserId, x.PodcastEpisodeId });
                    table.ForeignKey(
                        name: "FK_UserPodcastFavourite_PodcastEpisode_PodcastEpisodeId",
                        column: x => x.PodcastEpisodeId,
                        principalTable: "PodcastEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPodcastFavourite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPodcastPlaylist",
                columns: table => new
                {
                    PodcastEpisodeId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPodcastPlaylist", x => new { x.UserId, x.PlaylistId, x.PodcastEpisodeId });
                    table.ForeignKey(
                        name: "FK_UserPodcastPlaylist_PodcastPlaylist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "PodcastPlaylist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPodcastPlaylist_PodcastEpisode_PodcastEpisodeId",
                        column: x => x.PodcastEpisodeId,
                        principalTable: "PodcastEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPodcastPlaylist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenrePodcast",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    PodcastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenrePodcast", x => new { x.GenreId, x.PodcastId });
                    table.ForeignKey(
                        name: "FK_GenrePodcast_PodcastGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "PodcastGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenrePodcast_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerieRatingReview",
                columns: table => new
                {
                    SerieEpisodeId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieRatingReview", x => new { x.UserId, x.SerieEpisodeId });
                    table.ForeignKey(
                        name: "FK_SerieRatingReview_SerieEpisode_SerieEpisodeId",
                        column: x => x.SerieEpisodeId,
                        principalTable: "SerieEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerieRatingReview_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSerieFavourite",
                columns: table => new
                {
                    SerieEpisodeId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSerieFavourite", x => new { x.SerieEpisodeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserSerieFavourite_SerieEpisode_SerieEpisodeId",
                        column: x => x.SerieEpisodeId,
                        principalTable: "SerieEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSerieFavourite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSeriePlaylist",
                columns: table => new
                {
                    SerieEpisodeId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeriePlaylist", x => new { x.UserId, x.SerieEpisodeId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_UserSeriePlaylist_SeriePlaylist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "SeriePlaylist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSeriePlaylist_SerieEpisode_SerieEpisodeId",
                        column: x => x.SerieEpisodeId,
                        principalTable: "SerieEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSeriePlaylist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmRatingReview_UserId",
                table: "FilmRatingReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreFilm_GenreId",
                table: "GenreFilm",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMuziek_NummerId",
                table: "GenreMuziek",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_GenrePodcast_PodcastId",
                table: "GenrePodcast",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSerie_SerieId",
                table: "GenreSerie",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_MuziekRatingReview_NummerId",
                table: "MuziekRatingReview",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_Nummer_AlbumId",
                table: "Nummer",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Nummer_ArtiestId",
                table: "Nummer",
                column: "ArtiestId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastEpisode_PodcastId",
                table: "PodcastEpisode",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastGenre_PodcastId",
                table: "PodcastGenre",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastRatingReview_UserId",
                table: "PodcastRatingReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisseurFilm_RegisseurId",
                table: "RegisseurFilm",
                column: "RegisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_SerieEpisode_SerieId",
                table: "SerieEpisode",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_SerieRatingReview_SerieEpisodeId",
                table: "SerieRatingReview",
                column: "SerieEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFilmPlaylist_FilmId",
                table: "UserFilmPlaylist",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFilmPlaylist_PlaylistId",
                table: "UserFilmPlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMuziekFavourite_NummerId",
                table: "UserMuziekFavourite",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMuziekFavourite_UserId",
                table: "UserMuziekFavourite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMuziekPlaylist_NummerId",
                table: "UserMuziekPlaylist",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMuziekPlaylist_PlaylistId",
                table: "UserMuziekPlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPodcastFavourite_PodcastEpisodeId",
                table: "UserPodcastFavourite",
                column: "PodcastEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPodcastPlaylist_PlaylistId",
                table: "UserPodcastPlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPodcastPlaylist_PodcastEpisodeId",
                table: "UserPodcastPlaylist",
                column: "PodcastEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSerieFavourite_UserId",
                table: "UserSerieFavourite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeriePlaylist_PlaylistId",
                table: "UserSeriePlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeriePlaylist_SerieEpisodeId",
                table: "UserSeriePlaylist",
                column: "SerieEpisodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmRatingReview");

            migrationBuilder.DropTable(
                name: "GenreFilm");

            migrationBuilder.DropTable(
                name: "GenreMuziek");

            migrationBuilder.DropTable(
                name: "GenrePodcast");

            migrationBuilder.DropTable(
                name: "GenreSerie");

            migrationBuilder.DropTable(
                name: "MuziekRatingReview");

            migrationBuilder.DropTable(
                name: "PodcastRatingReview");

            migrationBuilder.DropTable(
                name: "RegisseurFilm");

            migrationBuilder.DropTable(
                name: "SerieRatingReview");

            migrationBuilder.DropTable(
                name: "UserFilmFavourite");

            migrationBuilder.DropTable(
                name: "UserFilmPlaylist");

            migrationBuilder.DropTable(
                name: "UserMuziekFavourite");

            migrationBuilder.DropTable(
                name: "UserMuziekPlaylist");

            migrationBuilder.DropTable(
                name: "UserPodcastFavourite");

            migrationBuilder.DropTable(
                name: "UserPodcastPlaylist");

            migrationBuilder.DropTable(
                name: "UserSerieFavourite");

            migrationBuilder.DropTable(
                name: "UserSeriePlaylist");

            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "MuziekGenre");

            migrationBuilder.DropTable(
                name: "PodcastGenre");

            migrationBuilder.DropTable(
                name: "SerieGenre");

            migrationBuilder.DropTable(
                name: "FilmRegisseur");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "FilmPlaylist");

            migrationBuilder.DropTable(
                name: "Nummer");

            migrationBuilder.DropTable(
                name: "MuziekPlaylist");

            migrationBuilder.DropTable(
                name: "PodcastPlaylist");

            migrationBuilder.DropTable(
                name: "PodcastEpisode");

            migrationBuilder.DropTable(
                name: "SeriePlaylist");

            migrationBuilder.DropTable(
                name: "SerieEpisode");

            migrationBuilder.DropTable(
                name: "MuziekAlbum");

            migrationBuilder.DropTable(
                name: "MuziekArtiest");

            migrationBuilder.DropTable(
                name: "Podcast");

            migrationBuilder.DropTable(
                name: "Serie");
        }
    }
}
