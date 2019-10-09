using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Film
{
    public class FilmCreateViewModel
    {
        [Required(ErrorMessage ="Titel is verplicht!")]
        [DisplayName("Titel *:")]
        public string Titel { get; set; }
        [DisplayName("Afspeel lengte (in min)*:")]
        [Required(ErrorMessage ="Lengte is verplicht!")]
        public int Lengte { get; set; }
        [DisplayName("Beschrijving :")]
        public string Beschrijving { get; set; }

        [DisplayName("Film genre :")]
        public List<string> GenresList { get; set; }
        [DisplayName("Regisseur(s) :")]
        public List<string> Regisseurs { get; set; }

        [DisplayName("Foto *:")]
        public IFormFile Foto { get; set; }

    }
}
