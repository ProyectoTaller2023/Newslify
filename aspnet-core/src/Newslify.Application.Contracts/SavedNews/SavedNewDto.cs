using System;
using Volo.Abp.Application.Dtos;
using Newslify.Keywords;
using Newslify.ReadingLists;
using System.Collections.Generic;

namespace Newslify.SavedNews
{
    public class SavedNewDto : EntityDto<int>
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string UrlToImage { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string Content { get; set; }

        public ICollection<KeywordDto> Keywords { get; set; }
        public ICollection<ReadingListDto> ReadingLists { get; set; }
    }
}