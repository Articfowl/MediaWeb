using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Film
{
    public class FilmEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Titel is verplicht!")]
        [DisplayName("Titel *:")]
        public string Titel { get; set; }
        [DisplayName("Afspeel lengte (in min)*:")]
        [Required(ErrorMessage = "Lengte is verplicht!")]
        public int Lengte { get; set; }
        [DisplayName("Beschrijving :")]
        public string Beschrijving { get; set; }
        [DisplayName("Film genre :")]
        public List<string> GenresList { get; set; }

        public List<string> SelectedGenres { get; set; }
        [DisplayName("Regisseur(s) :")]
        public List<string> Regisseurs { get; set; }
        public byte[] HuidigeFoto { get; set; }

        [DisplayName("Foto *:")]
        public IFormFile Foto { get; set; }

        public string GetPicture
        {
            get
            {
                if (HuidigeFoto == null)
                {
                    return null;
                }
                string mimeType = "png";
                string base64 = Convert.ToBase64String(HuidigeFoto);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }
        }
    }
}
