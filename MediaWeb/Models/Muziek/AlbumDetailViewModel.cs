using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class AlbumDetailViewModel
    {
        public int Id { get; set; }
        public string Artiest { get; set; }
        public int ArtiestId { get; set; }
        public string Titel { get; set; }
        public List<string> Nummers { get; set; }
        public List<int> NummersId { get; set; }
        public byte[] AlbumArt { get; set; }

        public string GetPicture
        {
            get
            {
                string mimeType = "png";
                string base64 = Convert.ToBase64String(AlbumArt);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }
        }
    }
}
