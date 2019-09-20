using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Serie
{
    public class UserSeriePlaylist
    {
        public int SerieEpisodeId { get; set; }
        public SerieEpisode SerieEpisode { get; set; }
        public int PlaylistId { get; set; }
        public SeriePlaylist Playlist { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
