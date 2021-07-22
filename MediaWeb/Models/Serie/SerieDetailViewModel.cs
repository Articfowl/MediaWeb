using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Serie
{
    public class SerieDetailViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public byte[] SerieArt { get; set; }
        public int AantalGezien { get; set; } = 0;
        public string GezienStatus { get; set; }
        public List<SelectListItem> GezienStatusList { get; set; }
        public bool Favoriet { get; set; } = false;
        public int AantalFavoriet { get; set; } = 0;
        public string PlaylistId { get; set; }
        public List<SelectListItem> UserPlaylists { get; set; }
        public string GetPicture
        {
            get
            {
                string mimeType = "png";
                string base64 = Convert.ToBase64String(SerieArt);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }
        }
    }
}
