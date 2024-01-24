using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Newslify.SavedNews
{
    public class SavedNewsAppService : NewslifyAppService, ISavedNewsAppService
    {
        private readonly IRepository<SavedNew, int> _repository;

        public SavedNewsAppService(IRepository<SavedNew, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<SavedNewDto>> GetSavedNewsAsync()
        {
            var savedNews = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<SavedNew>, ICollection<SavedNewDto>>(savedNews);
        }
    }
}