using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class UserPodcastFavourite
    {
        public int PodcastEpisodeId { get; set; }
        public PodcastEpisode PodcastEpisode { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
