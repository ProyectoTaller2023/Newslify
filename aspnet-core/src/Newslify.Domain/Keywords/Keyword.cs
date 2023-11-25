using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Newslify.ReadingLists;
using Newslify.SavedNews;

namespace Newslify.Keywords
{
    public class Keyword : Entity<int>
    {
        public Keyword()
        {
        }

        public string KeyWord { get; set; }
        public ICollection<ReadingList> ReadingLists { get; set; }
        public ICollection<SavedNew> SavedNews { get; set; }
    }
}