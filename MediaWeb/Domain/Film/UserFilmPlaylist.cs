﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Film
{
    public class UserFilmPlaylist
    {
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int PlaylistId { get; set; }
        public FilmPlaylist Playlist { get; set; }
    }
}
