using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class MuziekEditViewModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        [DisplayName("Titel nummer *:")]
        public string SongTitel { get; set; }
        [DisplayName("Afspeel lengte (in sec) *:")]
        public int Lengte { get; set; }
        [DisplayName("Naam artiest *:")]
        public string Artiest { get; set; }
        [DisplayName("Album titel *:")]
        public string AlbumTitel { get; set; }
        public bool Zichtbaar { get; set; }
        [DisplayName("Huidige album art")]
        public byte[] CurrentArt { get; set; }
        public IFormFile AlbumArt { get; set; }
        public string GetPicture
        {
            get
            {
                string mimeType = "png";
                string base64 = Convert.ToBase64String(CurrentArt);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }
        }
    }
}
