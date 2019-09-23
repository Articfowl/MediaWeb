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
        public int PlaylistId { get; set; }
        public string UserId { get; set; }
    }
}
