﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Muziek
{
    public class UserMuziekFavourite
    {
        public int MuziekId { get; set; }
        public string UserId { get; set; }
    }
}
