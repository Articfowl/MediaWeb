using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class MuziekDetailViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Lengte { get; set; }
        public string Artiest { get; set; }
        public int ArtiestId { get; set; }
        public string Album{ get; set; }
        public int AlbumId { get; set; }
        public bool Zichtbaar { get; set; }
    }
}
