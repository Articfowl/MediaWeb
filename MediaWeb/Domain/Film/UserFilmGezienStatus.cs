using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Film
{
    public class UserFilmGezienStatus
    {
        public string UserId { get; set; }
        public int StatusId { get; set; }
        public int FilmId { get; set; }
    }
}
