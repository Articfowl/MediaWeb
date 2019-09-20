using System;
using System.Collections.Generic;
using System.Text;
using MediaWeb.Domain.Film;
using MediaWeb.Domain.Podcast;
using MediaWeb.Domain.Muziek;
using MediaWeb.Domain.Serie;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
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
        // Muziek DbSets
        public DbSet<Nummer> Nummer { get; set; }
        public DbSet<GenreMuziek> GenreMuziek { get; set; }
        public DbSet<MuziekAlbum> MuziekAlbum { get; set; }
        public DbSet<MuziekArtiest> MuziekArtiest { get; set; }
        public DbSet<MuziekGenre> MuziekGenre { get; set; }
        public DbSet<MuziekPlaylist> MuziekPlaylist { get; set; }
        public DbSet<MuziekRatingReview> MuziekRatingReview { get; set; }
        public DbSet<UserMuziekFavourite> UserMuziekFavourite { get; set; }
        public DbSet<UserMuziekPlaylist> UserMuziekPlaylist { get; set; }
        // Podcast DbSets
        public DbSet<GenrePodcast> GenrePodcast { get; set; }
        public DbSet<Podcast> Podcast { get; set; }
        public DbSet<PodcastEpisode> PodcastEpisode { get; set; }
        public DbSet<PodcastGenre> PodcastGenre { get; set; }
        public DbSet<PodcastPlaylist> PodcastPlaylist { get; set; }
        public DbSet<PodcastRatingReview> RatingReviews { get; set; }
        public DbSet<UserPodcastFavourite> UserPodcastFavourite { get; set; }
        public DbSet<UserPodcastPlaylist> UserPodcastPlaylist { get; set; }
        // Serie DbSets
        public DbSet<GenreSerie> GenreSerie { get; set; }
        public DbSet<Serie> Serie { get; set; }
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
            //Fixing Table Names
            //Film
            builder.Entity<Film>().ToTable("Film");
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
            builder.Entity<MuziekGenre>().ToTable("MuziekGenre");
            builder.Entity<MuziekPlaylist>().ToTable("MuziekPlaylist");
            builder.Entity<MuziekRatingReview>().ToTable("MuziekRatingReview");
            builder.Entity<MuziekAlbum>().ToTable("MuziekAlbum");
            builder.Entity<GenreMuziek>().ToTable("GenreMuziek");
            builder.Entity<UserMuziekFavourite>().ToTable("UserMuziekFavourite");
            builder.Entity<UserMuziekPlaylist>().ToTable("UserMuziekPlaylist");
            builder.Entity<MuziekArtiest>().ToTable("MuziekArtiest");
            //Podcast
            builder.Entity<GenrePodcast>().ToTable("GenrePodcast");
            builder.Entity<Podcast>().ToTable("Podcast");
            builder.Entity<PodcastEpisode>().ToTable("PodcastEpisode");
            builder.Entity<PodcastGenre>().ToTable("PodcastGenre");
            builder.Entity<PodcastPlaylist>().ToTable("PodcastPlaylist");
            builder.Entity<PodcastRatingReview>().ToTable("PodcastRatingReview");
            builder.Entity<UserPodcastFavourite>().ToTable("UserPodcastFavourite");
            builder.Entity<UserPodcastPlaylist>().ToTable("UserPodcastPlaylist");
            //Serie
            builder.Entity<GenreSerie>().ToTable("GenreSerie");
            builder.Entity<Serie>().ToTable("Serie");
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
            //Muziek
            builder.Entity<UserMuziekPlaylist>().HasKey(x => new { x.UserId, x.PlaylistId, x.MuziekId });
            builder.Entity<GenreMuziek>().HasKey(x => new { x.GenreId, x.MuziekId });
            builder.Entity<UserMuziekFavourite>().HasKey(x => new { x.MuziekId, x.UserId });
            builder.Entity<MuziekRatingReview>().HasKey(x => new { x.UserId, x.MuziekId });
            //Podcast
            builder.Entity<PodcastRatingReview>().HasKey(x => new { x.PodcastEpisodeId, x.UserId });
            builder.Entity<GenrePodcast>().HasKey(x => new { x.GenreId, x.PodcastId });
            builder.Entity<UserPodcastPlaylist>().HasKey(x => new { x.UserId, x.PlaylistId, x.PodcastEpisodeId });
            builder.Entity<UserPodcastFavourite>().HasKey(x => new { x.UserId, x.PodcastEpisodeId });
            //Serie
            builder.Entity<GenreSerie>().HasKey(x => new { x.GenreId, x.SerieId });
            builder.Entity<SerieRatingReview>().HasKey(x => new { x.UserId, x.SerieEpisodeId });
            builder.Entity<UserSerieFavourite>().HasKey(x => new { x.SerieEpisodeId, x.UserId });
            builder.Entity<UserSeriePlaylist>().HasKey(x => new { x.UserId, x.SerieEpisodeId, x.PlaylistId });
            base.OnModelCreating(builder);
        }
    }
}
