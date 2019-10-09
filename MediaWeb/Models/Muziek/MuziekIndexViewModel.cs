using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Muziek
{
    public class MuziekIndexViewModel
    {
        public List<string> Genres { get; set; }
        public List<MuziekListViewModel> MuziekListViewModels { get; set; }
        public List<string> SelectedGenres { get; set; }
    }
}
