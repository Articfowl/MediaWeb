﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Serie
{
    public class UserSerieGezienStatus
    {
        public int SerieId { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }
    }
}
