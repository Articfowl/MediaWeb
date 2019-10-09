using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class MuziekCreateViewModel
    {
        [Required(ErrorMessage ="Nummer moet een titel hebben!")]
        public string Titel { get; set; }
        public string AlbumTitel { get; set; }
        [Required(ErrorMessage = "Nummer moet een lengte hebben!")]
        [Range(10,100000,ErrorMessage ="Lengte moet tussen 10 en 100000 seconden.")]
        [DisplayName("Lengte (in sec) *:")]
        public int Lengte { get; set; }
        [Required(ErrorMessage ="Nummer moet een artiest hebben!")]
        [DisplayName("Naam artiest *:")]
        public string Artiest { get; set; }
        public List<string> AllGenres { get; set; }

    }
}
