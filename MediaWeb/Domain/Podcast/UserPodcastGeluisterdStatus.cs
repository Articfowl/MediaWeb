using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class UserPodcastGeluisterdStatus
    {
        public int PodcastId { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }
    }
}
