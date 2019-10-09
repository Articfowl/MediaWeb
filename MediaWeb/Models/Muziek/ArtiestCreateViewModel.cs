using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class ArtiestCreateViewModel
    {
        [DisplayName("Naam artiest/band *: ")]
        [Required(ErrorMessage ="De naam is verplicht!")]
        [MinLength(2,ErrorMessage ="De naam moet meer dan 1 character bevatten.")]
        public string Naam { get; set; }
    }
}
