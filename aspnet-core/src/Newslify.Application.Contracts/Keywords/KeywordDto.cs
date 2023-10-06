using System;
using Volo.Abp.Application.Dtos;

namespace Newslify.Keywords
{
    public class KeywordDto : EntityDto<int>
    {
        public string KeyWord { get; set; }
    }
}