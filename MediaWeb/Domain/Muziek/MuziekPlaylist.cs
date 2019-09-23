using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Muziek
{
    public class MuziekPlaylist
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string UserId { get; set; }
    }
}
