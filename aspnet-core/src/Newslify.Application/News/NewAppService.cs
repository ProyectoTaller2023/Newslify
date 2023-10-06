using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Newslify.News
{
    public class NewAppService : NewslifyAppService, INewAppService
    {
        private readonly IRepository<New, int> _repository;

        public NewAppService(IRepository<New, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<NewDto>> GetNewsAsync()
        {
            var news = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<New>, ICollection<NewDto>>(news);
        }

        /* public async Task<ThemeDto> GetThemesAsync(int id)
         {
             var theme = await _repository.GetAsync(id);

             return ObjectMapper.Map<Theme, ThemeDto>(theme);
         }*/
    }
}