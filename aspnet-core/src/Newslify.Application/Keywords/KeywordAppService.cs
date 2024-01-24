using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}