using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}

