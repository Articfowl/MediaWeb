using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Serie
{
    public class SerieRatingReview
    {
        public int SerieEpisodeId { get; set; }
        public string UserId { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
    }
}
