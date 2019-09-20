using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class GenrePodcast
    {
        public int GenreId { get; set; }
        public PodcastGenre Genre { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
    }
}
