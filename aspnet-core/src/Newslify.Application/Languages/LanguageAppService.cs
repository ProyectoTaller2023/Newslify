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
    public class LanguageAppService : NewslifyAppService, ILanguageAppService
    {
        private readonly IRepository<Language, int> _repository;

        public LanguageAppService(IRepository<Language, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<LanguageDto>> GetLanguagesAsync()
        {
            var languages = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<Language>, ICollection<LanguageDto>>(languages);
        }

       /* public async Task<ThemeDto> GetThemesAsync(int id)
        {
            var theme = await _repository.GetAsync(id);

            return ObjectMapper.Map<Theme, ThemeDto>(theme);
        }*/
    }
}

