using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.User
{
    public class ListCreateViewModel
    {
        public string Titel { get; set; }
        public string Type { get; set; }
        public List<SelectListItem> TypeList { get; set; }
    }
}
