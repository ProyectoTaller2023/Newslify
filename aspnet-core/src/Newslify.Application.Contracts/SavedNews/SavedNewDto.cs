using System;
using Volo.Abp.Application.Dtos;

namespace Newslify.SavedNews
{
    public class SavedNewDto : EntityDto<int>
    {
        public string Description { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
    }
}