using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "FilmGezienStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGezienStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmPlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
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
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmRegisseur", x => x.Id);
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
                name: "MuziekGeluisterdStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuziekGeluisterdStatus", x => x.Id);
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
                    Titel = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuziekPlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false),
                    SerieArt = table.Column<byte[]>(nullable: true)
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
                name: "SerieGezienStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieGezienStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriePlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriePlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSerieGezienStatus",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSerieGezienStatus", x => new { x.UserId, x.SerieId });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserFilmGezienStatus",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FilmId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilmGezienStatus", x => new { x.FilmId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserFilmGezienStatus_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
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
                });

            migrationBuilder.CreateTable(
                name: "MuziekAlbum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    ArtiestId = table.Column<int>(nullable: false),
                    AlbumArt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuziekAlbum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MuziekAlbum_MuziekArtiest_ArtiestId",
                        column: x => x.ArtiestId,
                        principalTable: "MuziekArtiest",
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
                        name: "FK_GenreSerie_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Nummer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Lengte = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false),
                    Zichtbaar = table.Column<bool>(nullable: false)
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
                        name: "FK_UserSeriePlaylist_SerieEpisode_SerieEpisodeId",
                        column: x => x.SerieEpisodeId,
                        principalTable: "SerieEpisode",
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
                    Review = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    NummerId = table.Column<int>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "UserMuziekGeluisterdStatus",
                columns: table => new
                {
                    MuziekId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    MuziekGeluisterdStatusId = table.Column<int>(nullable: false),
                    NummerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMuziekGeluisterdStatus", x => new { x.UserId, x.MuziekId });
                    table.ForeignKey(
                        name: "FK_UserMuziekGeluisterdStatus_Nummer_NummerId",
                        column: x => x.NummerId,
                        principalTable: "Nummer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                });

            migrationBuilder.InsertData(
                table: "FilmGenre",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Sci-Fi" },
                    { 3, "Action" },
                    { 4, "Thriller" },
                    { 5, "Drama" },
                    { 6, "Romance" },
                    { 7, "Comedy" },
                    { 8, "Animation" }
                });

            migrationBuilder.InsertData(
                table: "FilmGezienStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 4, "Wil ik zien" },
                    { 3, "Gezien" },
                    { 1, "Niet gezien" },
                    { 2, "Wil ik nooit zien" }
                });

            migrationBuilder.InsertData(
                table: "MuziekGeluisterdStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Niet geluisterd" },
                    { 2, "Wil ik niet naar luisteren" },
                    { 3, "Geluisterd" },
                    { 4, "Wil ik naar luisteren" }
                });

            migrationBuilder.InsertData(
                table: "MuziekGenre",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 7, "Alternative" },
                    { 10, "Punk" },
                    { 9, "Orchestral" },
                    { 8, "Instrumental" },
                    { 6, "Rap" },
                    { 3, "Metal" },
                    { 4, "Pop" },
                    { 2, "Jazz" },
                    { 1, "Rock" },
                    { 5, "Hip-hop" }
                });

            migrationBuilder.InsertData(
                table: "SerieGenre",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Sci-Fi" },
                    { 3, "Action" },
                    { 4, "Thriller" },
                    { 5, "Drama" },
                    { 6, "Romance" },
                    { 7, "Comedy" },
                    { 8, "Animation" }
                });

            migrationBuilder.InsertData(
                table: "SerieGezienStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 3, "Gezien" },
                    { 1, "Niet gezien" },
                    { 2, "Wil ik niet zien" },
                    { 4, "Wil ik zien" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMuziek_NummerId",
                table: "GenreMuziek",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSerie_SerieId",
                table: "GenreSerie",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_MuziekAlbum_ArtiestId",
                table: "MuziekAlbum",
                column: "ArtiestId");

            migrationBuilder.CreateIndex(
                name: "IX_MuziekRatingReview_NummerId",
                table: "MuziekRatingReview",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_Nummer_AlbumId",
                table: "Nummer",
                column: "AlbumId");

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
                name: "IX_UserMuziekFavourite_NummerId",
                table: "UserMuziekFavourite",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMuziekGeluisterdStatus_NummerId",
                table: "UserMuziekGeluisterdStatus",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMuziekPlaylist_NummerId",
                table: "UserMuziekPlaylist",
                column: "NummerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeriePlaylist_SerieEpisodeId",
                table: "UserSeriePlaylist",
                column: "SerieEpisodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "FilmGezienStatus");

            migrationBuilder.DropTable(
                name: "FilmPlaylist");

            migrationBuilder.DropTable(
                name: "FilmRatingReview");

            migrationBuilder.DropTable(
                name: "FilmRegisseur");

            migrationBuilder.DropTable(
                name: "GenreFilm");

            migrationBuilder.DropTable(
                name: "GenreMuziek");

            migrationBuilder.DropTable(
                name: "GenreSerie");

            migrationBuilder.DropTable(
                name: "MuziekGeluisterdStatus");

            migrationBuilder.DropTable(
                name: "MuziekGenre");

            migrationBuilder.DropTable(
                name: "MuziekPlaylist");

            migrationBuilder.DropTable(
                name: "MuziekRatingReview");

            migrationBuilder.DropTable(
                name: "RegisseurFilm");

            migrationBuilder.DropTable(
                name: "SerieGenre");

            migrationBuilder.DropTable(
                name: "SerieGezienStatus");

            migrationBuilder.DropTable(
                name: "SeriePlaylist");

            migrationBuilder.DropTable(
                name: "SerieRatingReview");

            migrationBuilder.DropTable(
                name: "UserFilmFavourite");

            migrationBuilder.DropTable(
                name: "UserFilmGezienStatus");

            migrationBuilder.DropTable(
                name: "UserFilmPlaylist");

            migrationBuilder.DropTable(
                name: "UserMuziekFavourite");

            migrationBuilder.DropTable(
                name: "UserMuziekGeluisterdStatus");

            migrationBuilder.DropTable(
                name: "UserMuziekPlaylist");

            migrationBuilder.DropTable(
                name: "UserSerieFavourite");

            migrationBuilder.DropTable(
                name: "UserSerieGezienStatus");

            migrationBuilder.DropTable(
                name: "UserSeriePlaylist");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Nummer");

            migrationBuilder.DropTable(
                name: "SerieEpisode");

            migrationBuilder.DropTable(
                name: "MuziekAlbum");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "MuziekArtiest");
        }
    }
}
