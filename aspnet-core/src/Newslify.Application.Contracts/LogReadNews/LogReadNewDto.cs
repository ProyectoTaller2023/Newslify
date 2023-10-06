using System;
using Volo.Abp.Application.Dtos;

namespace Newslify.LogReadNews
{
    public class LogReadNewDto : EntityDto<int>
    {
        public string Url { get; set; }
        public DateTime DateRead { get; set; }
        public Guid userId { get; set; }
    }
}