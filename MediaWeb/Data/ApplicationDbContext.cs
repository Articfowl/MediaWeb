using System;
using System.Collections.Generic;
using System.Text;
using MediaWeb.Domain.Film;
using MediaWeb.Domain.Muziek;
using MediaWeb.Domain.Serie;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        //DbSets

        //Film DbSets
        public DbSet<Film> Film { get; set; }
        public DbSet<FilmGenre> FilmGenre { get; set; }
        public DbSet<FilmPlaylist> FilmPlaylist { get; set; }
        public DbSet<FilmRatingReview> FilmRatingReview { get; set; }
        public DbSet<FilmRegisseur> FilmRegisseur { get; set; }
        public DbSet<GenreFilm> GenreFilm { get; set; }
        public DbSet<RegisseurFilm> RegisseurFilm { get; set; }
        public DbSet<UserFilmFavourite> UserFilmFavourite { get; set; }
        public DbSet<UserFilmPlaylist> UserFilmPlaylist { get; set; }
        public DbSet<FilmGezienStatus> FilmGezienStatus { get; set; }
        public DbSet<UserFilmGezienStatus> UserFilmGezienStatus { get; set; }
        // Muziek DbSets
        public DbSet<Nummer> Nummer { get; set; }
        public DbSet<MuziekGeluisterdStatus> MuziekGeluisterdStatus { get; set; }
        public DbSet<UserMuziekGeluisterdStatus> UserMuziekGeluisterdStatus { get; set; }
        public DbSet<GenreMuziek> GenreMuziek { get; set; }
        public DbSet<MuziekAlbum> MuziekAlbum { get; set; }
        public DbSet<MuziekArtiest> MuziekArtiest { get; set; }
        public DbSet<MuziekGenre> MuziekGenre { get; set; }
        public DbSet<MuziekPlaylist> MuziekPlaylist { get; set; }
        public DbSet<MuziekRatingReview> MuziekRatingReview { get; set; }
        public DbSet<UserMuziekFavourite> UserMuziekFavourite { get; set; }
        public DbSet<UserMuziekPlaylist> UserMuziekPlaylist { get; set; }
        // Serie DbSets
        public DbSet<GenreSerie> GenreSerie { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<SerieGezienStatus> SerieGezienStatus { get; set; }
        public DbSet<UserSerieGezienStatus> UserSerieGezienStatus { get; set; }
        public DbSet<SerieEpisode> SerieEpisode { get; set; }
        public DbSet<SerieGenre> SerieGenre { get; set; }
        public DbSet<SeriePlaylist> SeriePlaylist { get; set; }
        public DbSet<SerieRatingReview> SerieRatingReview { get; set; }
        public DbSet<UserSerieFavourite> UserSerieFavourite { get; set; }
        public DbSet<UserSeriePlaylist> UserSeriePlaylist { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Table Names

            //Film
            builder.Entity<Film>().ToTable("Film");
            builder.Entity<FilmGezienStatus>().ToTable("FilmGezienStatus");
            builder.Entity<UserFilmGezienStatus>().ToTable("UserFilmGezienStatus");
            builder.Entity<FilmGenre>().ToTable("FilmGenre");
            builder.Entity<FilmPlaylist>().ToTable("FilmPlaylist");
            builder.Entity<FilmRatingReview>().ToTable("FilmRatingReview");
            builder.Entity<FilmRegisseur>().ToTable("FilmRegisseur");
            builder.Entity<GenreFilm>().ToTable("GenreFilm");
            builder.Entity<RegisseurFilm>().ToTable("RegisseurFilm");
            builder.Entity<UserFilmFavourite>().ToTable("UserFilmFavourite");
            builder.Entity<UserFilmPlaylist>().ToTable("UserFilmPlaylist");
            //Muziek
            builder.Entity<Nummer>().ToTable("Nummer");
            builder.Entity<MuziekGeluisterdStatus>().ToTable("MuziekGeluisterdStatus");
            builder.Entity<UserMuziekGeluisterdStatus>().ToTable("UserMuziekGeluisterdStatus");
            builder.Entity<MuziekGenre>().ToTable("MuziekGenre");
            builder.Entity<MuziekPlaylist>().ToTable("MuziekPlaylist");
            builder.Entity<MuziekRatingReview>().ToTable("MuziekRatingReview");
            builder.Entity<MuziekAlbum>().ToTable("MuziekAlbum");
            builder.Entity<GenreMuziek>().ToTable("GenreMuziek");
            builder.Entity<UserMuziekFavourite>().ToTable("UserMuziekFavourite");
            builder.Entity<UserMuziekPlaylist>().ToTable("UserMuziekPlaylist");
            builder.Entity<MuziekArtiest>().ToTable("MuziekArtiest");
            //Serie
            builder.Entity<GenreSerie>().ToTable("GenreSerie");
            builder.Entity<Serie>().ToTable("Serie");
            builder.Entity<SerieGezienStatus>().ToTable("SerieGezienStatus");
            builder.Entity<UserSerieGezienStatus>().ToTable("UserSerieGezienStatus");
            builder.Entity<SerieEpisode>().ToTable("SerieEpisode");
            builder.Entity<SerieGenre>().ToTable("SerieGenre");
            builder.Entity<SeriePlaylist>().ToTable("SeriePlaylist");
            builder.Entity<SerieRatingReview>().ToTable("SerieRatingReview");
            builder.Entity<UserSerieFavourite>().ToTable("UserSerieFavourite");
            builder.Entity<UserSeriePlaylist>().ToTable("UserSeriePlaylist");
            //Creating Multiple Field Primary Keys
            //Film
            builder.Entity<RegisseurFilm>().HasKey(x => new { x.FilmId, x.RegisseurId });
            builder.Entity<FilmRatingReview>().HasKey(x => new { x.FilmId, x.UserId });
            builder.Entity<GenreFilm>().HasKey(x => new { x.FilmId, x.GenreId });
            builder.Entity<UserFilmPlaylist>().HasKey(x => new { x.UserId, x.PlaylistId, x.FilmId });
            builder.Entity<UserFilmFavourite>().HasKey(x => new { x.FilmId, x.UserId });
            builder.Entity<UserFilmGezienStatus>().HasKey(x => new { x.FilmId, x.UserId });
            //Muziek
            builder.Entity<UserMuziekPlaylist>().HasKey(x => new { x.UserId, x.PlaylistId, x.MuziekId });
            builder.Entity<GenreMuziek>().HasKey(x => new { x.GenreId, x.MuziekId });
            builder.Entity<UserMuziekFavourite>().HasKey(x => new { x.MuziekId, x.UserId });
            builder.Entity<MuziekRatingReview>().HasKey(x => new { x.UserId, x.MuziekId });
            builder.Entity<UserMuziekGeluisterdStatus>().HasKey(x => new { x.UserId, x.MuziekId });
            
            //Serie
            builder.Entity<GenreSerie>().HasKey(x => new { x.GenreId, x.SerieId });
            builder.Entity<SerieRatingReview>().HasKey(x => new { x.UserId, x.SerieEpisodeId });
            builder.Entity<UserSerieFavourite>().HasKey(x => new { x.SerieEpisodeId, x.UserId });
            builder.Entity<UserSeriePlaylist>().HasKey(x => new { x.UserId, x.SerieEpisodeId, x.PlaylistId });
            builder.Entity<UserSerieGezienStatus>().HasKey(x => new { x.UserId, x.SerieId });

            //Seeding Tables With Data
            //Film
            builder.Entity<FilmGenre>().HasData(new FilmGenre() { Id = 1, Genre = "Horror" }, new FilmGenre() { Id = 2, Genre = "Sci-Fi" },
                new FilmGenre() { Id = 3, Genre = "Action" }, new FilmGenre() { Id = 4, Genre = "Thriller" },
                new FilmGenre() { Id = 5, Genre = "Drama" }, new FilmGenre() { Id = 6, Genre = "Romance" },
                new FilmGenre() { Id = 7, Genre = "Comedy" }, new FilmGenre() { Id = 8, Genre = "Animation" });
            builder.Entity<FilmGezienStatus>().HasData(new FilmGezienStatus() { Id = 1, Status = "Niet gezien" },
                new FilmGezienStatus() { Id = 2, Status = "Wil ik nooit zien" }, new FilmGezienStatus() { Id = 3, Status = "Gezien" },
                new FilmGezienStatus() { Id = 4, Status = "Wil ik zien" });

            //Muziek
            builder.Entity<MuziekGenre>().HasData(new MuziekGenre() { Id = 1, Genre = "Rock" }, new MuziekGenre() { Id = 2, Genre = "Jazz" },
                new MuziekGenre() { Id = 3, Genre = "Metal" }, new MuziekGenre() { Id = 4, Genre = "Pop" },
                new MuziekGenre() { Id = 5, Genre = "Hip-hop" }, new MuziekGenre() { Id = 6, Genre = "Rap" },
                new MuziekGenre() { Id = 7, Genre = "Alternative" }, new MuziekGenre() { Id = 8, Genre = "Instrumental" },
                new MuziekGenre() { Id = 9, Genre = "Orchestral" }, new MuziekGenre() { Id = 10, Genre = "Punk" });
            builder.Entity<MuziekGeluisterdStatus>().HasData(new MuziekGeluisterdStatus() { Id = 1, Status = "Niet geluisterd" },
                new MuziekGeluisterdStatus() { Id = 2, Status = "Wil ik niet naar luisteren" },
                new MuziekGeluisterdStatus() { Id = 3, Status = "Geluisterd" }, 
                new MuziekGeluisterdStatus() { Id = 4, Status = "Wil ik naar luisteren" });
           
            //Serie
            builder.Entity<SerieGenre>().HasData(new SerieGenre() { Id = 1, Genre = "Horror" }, new SerieGenre() { Id = 2, Genre = "Sci-Fi" },
                new SerieGenre() { Id = 3, Genre = "Action" }, new SerieGenre() { Id = 4, Genre = "Thriller" },
                new SerieGenre() { Id = 5, Genre = "Drama" }, new SerieGenre() { Id = 6, Genre = "Romance" },
                new SerieGenre() { Id = 7, Genre = "Comedy" }, new SerieGenre() { Id = 8, Genre = "Animation" });
            builder.Entity<SerieGezienStatus>().HasData(new SerieGezienStatus() { Id = 1, Status = "Niet gezien" },
                new SerieGezienStatus() { Id = 2, Status = "Wil ik niet zien" },
                new SerieGezienStatus() { Id = 3, Status = "Gezien" },
                new SerieGezienStatus() { Id = 4, Status = "Wil ik zien" },
                new SerieGezienStatus() { Id = 5, Status = "Nog niet alles gezien" });
            base.OnModelCreating(builder);
        }
    }
}
