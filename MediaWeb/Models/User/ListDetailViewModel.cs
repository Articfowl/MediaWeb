using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.User
{
    public class ListDetailViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Type { get; set; }
        public List<ListItemViewModel> Items { get; set; }
    }
}
