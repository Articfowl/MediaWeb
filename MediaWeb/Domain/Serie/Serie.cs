using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Serie
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public bool Zichtbaar { get; set; } = true;
        public byte[] SerieArt { get; set; }
        public ICollection<SerieEpisode> Episode { get; set; }
        public ICollection<GenreSerie> Genres { get; set; }
    }
}
