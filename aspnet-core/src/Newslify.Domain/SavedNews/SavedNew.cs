using Newslify.Keywords;
using Newslify.ReadingLists;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Newslify.SavedNews
{
    public class SavedNew : Entity<int>
    {

        public SavedNew()
        {
            this.Keywords = new List<Keyword>();
            this.ReadingLists = new List<ReadingList>();
        }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string UrlToImage { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string Content { get; set; }

        public ICollection<Keyword> Keywords { get; set; }
        public ICollection<ReadingList> ReadingLists { get; set; }
    }
}