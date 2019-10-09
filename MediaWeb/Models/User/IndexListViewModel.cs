using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.User
{
    public class IndexListViewModel
    {
        public List<UserListViewModel> MuziekList { get; set; }
        public List<UserListViewModel> FilmList { get; set; }
        public List<UserListViewModel> SerieList { get; set; }
    }
}
