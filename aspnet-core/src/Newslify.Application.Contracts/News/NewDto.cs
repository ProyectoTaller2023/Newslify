using System;
using Volo.Abp.Application.Dtos;

namespace Newslify.News
{
    public class NewDto : EntityDto<int>
    {
        public string Description { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
    }
}