using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Serie
{
    public class SerieEpisode
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Lengte { get; set; }
        public int SerieId { get; set; }
        public Serie Serie { get; set; }
        public ICollection<UserSerieFavourite> Favourites { get; set; }
        public ICollection<UserSeriePlaylist> Playlist { get; set; }
        public ICollection<SerieRatingReview> RatingReviews { get; set; }
    }
}
