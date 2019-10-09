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
        public int  ArtiestId { get; set; }
        public MuziekArtiest Artiest { get; set; }
        public byte[] AlbumArt { get; set; }

    }
}