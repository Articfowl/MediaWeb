using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Muziek
{
    public class MuziekAlbum
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public ICollection<Nummer> Nummer { get; set; }

    }
}
