using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Film
{
    public class Film
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Lengte { get; set; }
        public string Beschrijving { get; set; }
        public bool Zichtbaar { get; set; } = true;
        public byte[] Foto { get; set; }
        public ICollection<GenreFilm> Genres { get; set; }
        public ICollection<FilmRatingReview> RatingReviews { get; set; }
        public ICollection<RegisseurFilm> Regisseurs { get; set; }
        public ICollection<UserFilmFavourite> Favourites { get; set; }
        public ICollection<UserFilmPlaylist> Playlists { get; set; }
        public ICollection<UserFilmGezienStatus> FilmGezienStatuses { get; set; }
    }
}
