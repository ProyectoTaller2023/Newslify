using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
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

        /* public async Task<ThemeDto> GetThemesAsync(int id)
         {
             var theme = await _repository.GetAsync(id);

             return ObjectMapper.Map<Theme, ThemeDto>(theme);
         }*/
    }
}