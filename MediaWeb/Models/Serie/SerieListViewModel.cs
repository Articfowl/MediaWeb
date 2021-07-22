using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Serie
{
    public class SerieListViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Lengte { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public byte[] FilmArt { get; set; }

        public string GetPicture
        {
            get
            {
                string mimeType = "png";
                string base64 = Convert.ToBase64String(FilmArt);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }
        }
    }
}
