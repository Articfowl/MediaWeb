﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Serie
{
    public class SerieCreateViewModel
    {
        [Required(ErrorMessage = "Titel is verplicht!")]
        [DisplayName("Titel *:")]
        public string Titel { get; set; }
        [DisplayName("Aantal afleveringen:")]
        [Required(ErrorMessage = "Lengte is verplicht!")]
        public int Lengte { get; set; }
        [DisplayName("Beschrijving :")]
        public string Beschrijving { get; set; }

        [DisplayName("Serie genre :")]
        public List<string> GenresList { get; set; }

        [DisplayName("Foto *:")]
        public IFormFile Foto { get; set; }
    }
}
