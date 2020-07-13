using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Announcement.Models
{
    public class AnnounceViewList
    {
        public IEnumerable<Announce> Announces { get; set; }
        public int Id { set; get; }
        public string Title { get; set; }
        public string Description { get; set;}
        public string Data_Added { get; set; }
    }
}
