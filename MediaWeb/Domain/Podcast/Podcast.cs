using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public bool Zichtbaar { get; set; }
        public ICollection<PodcastGenre> Genres {get;set;}
        public ICollection<PodcastEpisode> Episodes { get; set; }
    }
}
