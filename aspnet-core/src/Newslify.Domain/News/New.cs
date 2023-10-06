using Newslify.Keywords;
using Newslify.ReadingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Newslify.News
{
    public class New : Entity<int>
    {
        public string Description { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }

        public ICollection<Keyword> Keywords { get; set; }
        public ICollection<ReadingList> ReadingLists { get; set; }
    }
}