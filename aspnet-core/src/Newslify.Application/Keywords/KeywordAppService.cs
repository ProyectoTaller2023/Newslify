using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Newslify.Keywords
{
    public class KeywordAppService : NewslifyAppService, IKeywordAppService
    {
        private readonly IRepository<Keyword, int> _repository;

        public KeywordAppService(IRepository<Keyword, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<KeywordDto>> GetKeywordsAsync()
        {
            var keywords = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<Keyword>, ICollection<KeywordDto>>(keywords);
        }

        /* public async Task<ThemeDto> GetThemesAsync(int id)
         {
             var theme = await _repository.GetAsync(id);

             return ObjectMapper.Map<Theme, ThemeDto>(theme);
         }*/
    }
}