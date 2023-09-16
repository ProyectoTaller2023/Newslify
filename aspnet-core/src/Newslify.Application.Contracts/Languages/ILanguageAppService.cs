using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Newslify.Languages
{
    public interface ILanguageAppService: ICrudAppService<LanguageDto,int>
    {

    }
}
