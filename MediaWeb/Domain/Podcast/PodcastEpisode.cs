using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class PodcastEpisode
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Lengte { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
        public ICollection<PodcastRatingReview> RatingReviews { get; set; }
        public ICollection<UserPodcastPlaylist> Playlists { get; set; }
        public ICollection<UserPodcastFavourite> Favourites { get; set; }
    }
}
