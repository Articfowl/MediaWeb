using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class ArtiestDetailViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<string> Albums { get; set; }
        public List<int> AlbumIds { get; set; }
    }
}
