using System;
using Volo.Abp.Application.Dtos;

namespace Newslify.Languages
{
    public class LanguageDto : EntityDto<int>
    {
        public string? Name { get; set; }

        public LanguageIntCodeType InternationalCode { get; set; }
    }
}


