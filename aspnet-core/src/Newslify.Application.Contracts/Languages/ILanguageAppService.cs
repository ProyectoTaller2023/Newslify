using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Newslify.Languages
{
    public interface ILanguageAppService: IApplicationService
    {
        Task<ICollection<LanguageDto>> GetLanguagesAsync();
    }
}
