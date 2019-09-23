using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Muziek
{
    public class UserMuziekGeluisterdStatus
    {
        public int MuziekGeluisterdStatusId { get; set; }
        public int MuziekId { get; set; }
        public string UserId { get; set; }
    }
}
