using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Film
{
    public class FilmRatingReview
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }

    }
}
