using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class AlbumCreateViewModel
    {
        [DisplayName("Album Titel *: ")]
        [Required(ErrorMessage ="Titel is verplicht!")]
        public string Titel { get; set; }
        [DisplayName("Album art *: ")]
        [Required(ErrorMessage ="Album art is verplicht! \nSelecteer eventueel een placeholder..")]

        public IFormFile AlbumArt { get; set; }
        //[Required(ErrorMessage ="Artiest is verplicht! Elk album heeft een artiest!!")]
        //[DisplayName("Naam artiest* : ")]
        public string Artiest { get; set; }
    }
}
