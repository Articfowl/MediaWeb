﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Muziek
{
    public class GenreMuziek
    {
        public int GenreId { get; set; }
        public MuziekGenre Genre { get; set; }
        public int MuziekId { get; set; }
        public Nummer Nummer { get; set; }
    }
}
