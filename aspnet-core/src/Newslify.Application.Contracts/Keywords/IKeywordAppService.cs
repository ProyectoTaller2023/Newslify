using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Newslify.Keywords
{
    public interface IKeywordAppService : IApplicationService
    {
        Task<ICollection<KeywordDto>> GetKeywordsAsync();
    }
}