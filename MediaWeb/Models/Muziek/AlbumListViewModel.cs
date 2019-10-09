using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class AlbumListViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public List<string> Nummers { get; set; }
        public byte[]  AlbumArt { get; set; }

    }
}
