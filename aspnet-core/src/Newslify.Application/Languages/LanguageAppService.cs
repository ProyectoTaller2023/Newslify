using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Newslify.Languages
{
    public class LanguageAppService :
    CrudAppService<Language, LanguageDto, int>, ILanguageAppService
    {
        public LanguageAppService(IRepository<Language, int> repository)
            : base(repository)
        {

        }
    }
}

