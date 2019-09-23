using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Muziek
{
    public class Nummer
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Lengte { get; set; }
        public int ArtiestId { get; set; }
        public MuziekArtiest Artiest { get; set; }
        public int AlbumId { get; set; }
        public MuziekAlbum Album { get; set; }
        public bool Zichtbaar { get; set; }
        public ICollection<GenreMuziek> Genres { get; set; }
        public ICollection<MuziekRatingReview> RatingReviews { get; set; }
        public ICollection<UserMuziekFavourite> Favourites { get; set; }
        public ICollection<UserMuziekPlaylist> Playlists { get; set; }
        public ICollection<UserMuziekGeluisterdStatus> GeluisterdStatus { get; set; }
    }
}
